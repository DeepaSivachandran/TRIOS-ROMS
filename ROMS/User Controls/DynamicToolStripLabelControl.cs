using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ROMS
{
    [ToolboxItem(true)]
    [DesignerCategory("Code")]
    public class DynamicToolStripLabelControl : Component
    {
        MainForm objMainForm = new MainForm();
        public ToolStripLabel PlaceholderLabel { get; set; }

        private string[] LevelTexts = new string[4];
        private int[] LevelCodes = new int[4]; // MU_Code for each level
        private DataError objError;

        private static readonly ConcurrentDictionary<int, ContextMenuStrip> ContextMenuCache = new ConcurrentDictionary<int, ContextMenuStrip>();

        public event EventHandler<ToolStripLabelEventArgs> DynamicLabelClick;

        public void BindMenuHierarchy(int currentMenuCode)
        {
            try
            {
                if (PlaceholderLabel?.Owner == null) return;

                ToolStrip ts = PlaceholderLabel.Owner;
                int index = ts.Items.IndexOf(PlaceholderLabel);
                if (index < 0) return;

                ts.Items.RemoveAt(index);

                DataTable dt = MainForm.objDtMenuDetailsUser;
                if (dt == null || dt.Rows.Count == 0) return;

                // Traverse levels from current menu code up to root — critical for breadcrumb hierarchy
                int levelIndex = 3;
                int code = currentMenuCode;

                while (code != 0 && levelIndex >= 0)
                {
                    var row = dt.AsEnumerable().FirstOrDefault(r => r.Field<int>("MU_Code") == code && r.Field<int>("MU_EQID") == 0);
                    if (row == null) break;

                    LevelTexts[levelIndex] = row.Field<string>("MU_Name");
                    LevelCodes[levelIndex] = row.Field<int>("MU_Code");
                    code = row.Field<int?>("MU_ParentMenuCode") ?? 0;
                    levelIndex--;
                }

                var visibleLabels = new List<ToolStripLabel>();

                // Add breadcrumb labels dynamically
                for (int i = 0; i < 4; i++)
                {
                    if (string.IsNullOrWhiteSpace(LevelTexts[i])) continue;

                    try
                    {
                        int levelCode = LevelCodes[i];

                        ToolStripLabel lbl = new ToolStripLabel(LevelTexts[i])
                        {
                            Font = new Font("Oswald Regular", 11, FontStyle.Regular),
                            AutoSize = true,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Tag = levelCode,
                            Margin = new Padding(4, 0, 4, 0)
                        };

                        bool isFirstVisible = ts.Items.Cast<ToolStripItem>().OfType<ToolStripLabel>().Count() == 0;
                        lbl.Image = isFirstVisible
                            ? Properties.Resources.bread_crumb  // root label
                            : Properties.Resources.double_chevron; // child levels

                        lbl.ImageAlign = ContentAlignment.MiddleLeft;
                        lbl.TextImageRelation = TextImageRelation.ImageBeforeText;

                        visibleLabels.Add(lbl);
                        ts.Items.Insert(index++, lbl);
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                    }
                }

                // Set click events, skip context menu for last breadcrumb
                if (visibleLabels.Count > 0)
                {
                    var lastLabel = visibleLabels.Last();

                    foreach (var lbl in visibleLabels)
                    {
                        int levelCode = (int)lbl.Tag;

                        lbl.MouseDown += (s, e) =>
                        {
                            try
                            {
                                DynamicLabelClick?.Invoke(this, new ToolStripLabelEventArgs(lbl));

                                if (lbl == lastLabel)//check the level is final that time no need to show the sublevels
                                    return;

                                var row = dt.AsEnumerable().FirstOrDefault(r => r.Field<int>("MU_Code") == levelCode);
                                if (row != null)
                                {
                                    int level = row.Field<int>("MU_Level");
                                    if (level != 0)
                                    {
                                        ShowContextMenu(lbl, levelCode);//show child menu
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                objError = new DataError();
                                objError.WriteFile(ex);
                            }
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        // Show context menu relative to label — important for screen position
        private void ShowContextMenu(ToolStripLabel tsLabel, int parentMenuCode)
        {
            try
            {
                if (tsLabel == null) return;

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

        // Build dynamic context menu with child flattening
        private ContextMenuStrip CreateContextMenu(Form parentForm, int parentMenuCode)
        {
            try
            {
                if (ContextMenuCache.TryGetValue(parentMenuCode, out var cachedMenu))
                    return cachedMenu;

                ContextMenuStrip contextMenu = new ContextMenuStrip
                {
                    Font = new Font("Oswald", 10, FontStyle.Regular)
                };

                DataTable menuTableDummy = MainForm.objDtMenuDetailsUser;
                DataRow[] filteredRows = menuTableDummy.Select("MU_EQID = 0"); 
                DataTable menuTable = filteredRows.Length > 0
                    ? filteredRows.CopyToDataTable()
                    : menuTableDummy.Clone();

                if (menuTable == null || menuTable.Rows.Count == 0)
                    return contextMenu;

                var query = from row in menuTable.AsEnumerable()
                            where row.Field<int?>("MU_ParentMenuCode") == parentMenuCode
                                  && row.Field<int?>("MU_Level") != 0
                            orderby row.Field<int?>("MU_OrderID") ?? 0
                            select row;

                foreach (var row in query)
                {
                    try
                    {
                        string menuName = row.Field<string>("MenuDisplayname");
                        string formClass = row.Field<string>("MU_Formname");
                        int muCode = row.Field<int>("MU_Code");

                        // flatten child menus
                        bool hasChildren = menuTable.AsEnumerable()
                            .Any(r => r.Field<int?>("MU_ParentMenuCode") == muCode);

                        if (hasChildren)
                        {
                            var childItems = menuTable.AsEnumerable()
                                .Where(r => r.Field<int?>("MU_ParentMenuCode") == muCode)
                                .OrderBy(r => r.Field<int?>("MU_OrderID") ?? 0);

                            foreach (var child in childItems)
                            {
                                try
                                {
                                    string childName = child.Field<string>("MenuDisplayname");
                                    string childClass = child.Field<string>("MU_Formname");
                                    if (string.IsNullOrWhiteSpace(childName)) continue;

                                    ToolStripMenuItem menuItemChild = new ToolStripMenuItem(childName);
                                    menuItemChild.Click += (s, e) => OpenForm(childClass, parentForm, muCode);
                                    contextMenu.Items.Add(menuItemChild);
                                }
                                catch (Exception ex)
                                {
                                    objError = new DataError();
                                    objError.WriteFile(ex);
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(menuName)) continue;
                            ToolStripMenuItem menuItem = new ToolStripMenuItem(menuName);
                            menuItem.Click += (s, e) => OpenForm(formClass, parentForm, muCode);
                            contextMenu.Items.Add(menuItem);
                        }
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                    }
                }

                ContextMenuCache[parentMenuCode] = contextMenu;
                return contextMenu;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                return new ContextMenuStrip();
            }
        }

        // Open form dynamically — for MDI handling
        private void OpenForm(string formClass, Form parentForm, int menucode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(formClass)) return;

                Type formType = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .FirstOrDefault(t => t.Name.Equals(formClass, StringComparison.OrdinalIgnoreCase));

                if (formType == null) return;

                var staticField = typeof(MainForm).GetFields(BindingFlags.Public | BindingFlags.Static)
                    .FirstOrDefault(f => f.FieldType == formType);

                object formInstance = staticField?.GetValue(null) ?? Activator.CreateInstance(formType);

                if (staticField != null && staticField.GetValue(null) == null)
                {
                    staticField.SetValue(null, formInstance);
                }
                MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
                if (mainForm != null)
                {
                    var openReportMethod = typeof(MainForm).GetMethod("OpenReportForm",
                        BindingFlags.Public | BindingFlags.Instance);

                    var genericMethod = openReportMethod.MakeGenericMethod(formType);

                    object[] parameters = new object[] { formInstance, formClass, menucode, null };

                    genericMethod.Invoke(mainForm, parameters);

                    if (staticField != null)
                    {
                        staticField.SetValue(null, parameters[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

    }

    public class ToolStripLabelEventArgs : EventArgs
    {
        public ToolStripLabel Label { get; private set; }
        public int MenuCode => Label.Tag is int code ? code : 0;

        public ToolStripLabelEventArgs(ToolStripLabel label)
        {
            Label = label;
        }
    }
}
