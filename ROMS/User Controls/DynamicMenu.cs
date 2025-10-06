using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

public class DynamicMenu
{
    public static ContextMenuStrip CreateContextMenu(
        Form parentForm,
        int parentMenuCode,
        Func<int, DataTable> fetchMenuData // delegate to load data (DB or mock)
    )
    {
        ContextMenuStrip contextMenu = new ContextMenuStrip();
        contextMenu.Font = new Font("Oswald", 10, FontStyle.Regular);

        try
        {
            // Get data from DB
            DataTable menuTable = fetchMenuData(parentMenuCode);
            if (menuTable == null || menuTable.Rows.Count == 0)
                return contextMenu;

            foreach (DataRow row in menuTable.Rows)
            {
                string menuName = Convert.ToString(row["MU_Name"]);
                string formClassName = Convert.ToString(row["MU_Link"]);

                // Skip items with no link
                if (string.IsNullOrWhiteSpace(menuName))
                    continue;

                // Add the item dynamically
                contextMenu.Items.Add(menuName, null, (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(formClassName))
                        return;

                    try
                    {
                        // Dynamically create form instance
                        Type formType = Type.GetType(formClassName);
                        if (formType == null)
                        {
                            MessageBox.Show($"Form '{formClassName}' not found.", "Error");
                            return;
                        }

                        Form formInstance = (Form)Activator.CreateInstance(formType);

                        // Assign to MainForm property dynamically
                        string objectName = "obj" + formClassName;
                        var mainFormType = parentForm.GetType();
                        var prop = mainFormType.GetField(objectName, BindingFlags.Public | BindingFlags.Static);

                        if (prop != null)
                            prop.SetValue(null, formInstance);

                        formInstance.MdiParent = parentForm;
                        formInstance.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to open '{formClassName}'.\n{ex.Message}");
                    }
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error while creating context menu:\n{ex.Message}");
        }

        return contextMenu;
    }
}
