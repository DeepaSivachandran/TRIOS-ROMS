using ROMS;
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

public static class DynamicMenu
{
    private static DataError objError;
    // Cache built context menus by parentMenuCode
    private static readonly ConcurrentDictionary<int, ContextMenuStrip> ContextMenuCache = new ConcurrentDictionary<int, ContextMenuStrip>();

    // New method: creates menu and shows at ToolStripLabel position
    public static void CreateContextMenuAndShow(ToolStripLabel tsLabel, int parentMenuCode)
    {
        try
        {
            if (tsLabel == null) return;

            // Get the parent ToolStrip
            var parentStrip = tsLabel.GetCurrentParent();
            if (parentStrip == null) return;

            Form parentForm = tsLabel.Owner?.FindForm();
            if (parentForm == null) return;
            ContextMenuStrip contextMenu = CreateContextMenu(parentForm, parentMenuCode);
            var location = parentStrip.PointToScreen(new Point(
                tsLabel.Bounds.Left,
                tsLabel.Bounds.Bottom));
            contextMenu.Show(location);
        }
        catch (Exception ex)
        {
            objError = new DataError();
            objError.WriteFile(ex);
        }
    }


    public static ContextMenuStrip CreateContextMenu(Form parentForm, int parentMenuCode)
    {
        // Return cached menu if already built
        if (ContextMenuCache.TryGetValue(parentMenuCode, out var cachedMenu))
            return cachedMenu;

        // Create a new ContextMenuStrip instance
        ContextMenuStrip contextMenu = new ContextMenuStrip
        {
            Font = new Font("Oswald", 10, FontStyle.Regular)
        };

        try
        {
            // Access the in-memory DataTable that contains all menu details
            DataTable menuTable = MainForm.objDtMenuDetails;
            if (menuTable == null || menuTable.Rows.Count == 0)
                return contextMenu;

            // Filter rows in the DataTable where MU_ParentMenuCode matches the selected parentMenuCode
            var query = from row in menuTable.AsEnumerable()
                        where row.Field<int?>("MU_ParentMenuCode") == parentMenuCode
                        orderby row.Field<int?>("MU_OrderID") ?? 0
                        select new
                        {
                            MenuName = row.Field<string>("MenuDisplayname"),
                            FormClass = row.Field<string>("MU_Link")
                        };

            foreach (var item in query)
            {
                // Skip rows with empty or null menu names
                if (string.IsNullOrWhiteSpace(item.MenuName))
                    continue;

                // Create a new ToolStripMenuItem for this menu
                ToolStripMenuItem menuItem = new ToolStripMenuItem(item.MenuName);

                // Define what happens when this menu item is clicked
                menuItem.Click += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(item.FormClass))
                        return;

                    try
                    {
                        // Find form type in all loaded assemblies
                        Type formType = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(a => a.GetTypes())
                            .FirstOrDefault(t => t.Name.Equals(item.FormClass, StringComparison.OrdinalIgnoreCase));

                        if (formType == null)
                        {
                            //MessageBox.Show($"Form '{item.FormClass}' not found.", "Error");
                            return;
                        }

                        Form formInstance = (Form)Activator.CreateInstance(formType);

                        // Assign the instance to MainForm static field if exists (type-safe)
                        var staticFields = typeof(MainForm).GetFields(BindingFlags.Public | BindingFlags.Static);
                        var field = staticFields.FirstOrDefault(f =>
                            f.FieldType == formType ||
                            f.Name.IndexOf(item.FormClass, StringComparison.OrdinalIgnoreCase) >= 0);
                        field?.SetValue(null, formInstance);


                        // Show the form
                        Form mdiParent = parentForm?.ParentForm ?? parentForm;
                        formInstance.MdiParent = mdiParent;
                        formInstance.Show();
                        formInstance.BringToFront();
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                        //MessageBox.Show($"Error while opening '{item.FormClass}': {ex.Message}", "Exception");
                    }
                };
                contextMenu.Items.Add(menuItem);
            }

            // Cache the menu for future clicks
            ContextMenuCache[parentMenuCode] = contextMenu;
        }
        catch (Exception ex)
        {
            objError = new DataError();
            objError.WriteFile(ex);
            //MessageBox.Show($"Error creating context menu: {ex.Message}", "Exception");
        }

        return contextMenu;
    }
}
