using System;
using System.Collections.Concurrent;
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
        public ToolStripLabel PlaceholderLabel { get; set; }

        private string[] LevelTexts = new string[4];
        private int[] LevelCodes = new int[4]; // MU_Code for each level

        private Bitmap[] LabelImages => new Bitmap[]
        {
            Properties.Resources.bread_crumb,
            Properties.Resources.double_chevron,
            Properties.Resources.double_chevron,
            Properties.Resources.double_chevron
        };

        // Cache context menus by parent code
        private static readonly ConcurrentDictionary<int, ContextMenuStrip> ContextMenuCache = new ConcurrentDictionary<int, ContextMenuStrip>();

        public event EventHandler<ToolStripLabelEventArgs> DynamicLabelClick;


        public void BindMenuHierarchy(int currentMenuCode)
        {
            if (PlaceholderLabel?.Owner == null) return;

            ToolStrip ts = PlaceholderLabel.Owner;
            int index = ts.Items.IndexOf(PlaceholderLabel);
            if (index < 0) return;

            ts.Items.RemoveAt(index);

            DataTable dt = MainForm.objDtMenuDetails;
            if (dt == null || dt.Rows.Count == 0) return;

            int levelIndex = 3;
            int code = currentMenuCode;

            while (code != 0 && levelIndex >= 0)
            {
                var row = dt.AsEnumerable().FirstOrDefault(r => r.Field<int>("MU_Code") == code);
                if (row == null) break;

                LevelTexts[levelIndex] = row.Field<string>("MU_Name");
                LevelCodes[levelIndex] = row.Field<int>("MU_Code");
                code = row.Field<int?>("MU_ParentMenuCode") ?? 0;
                levelIndex--;
            }

            for (int i = 0; i < 4; i++)
            {
                if (string.IsNullOrWhiteSpace(LevelTexts[i])) continue;

                int levelCode = LevelCodes[i]; // safer copy

                ToolStripLabel lbl = new ToolStripLabel(LevelTexts[i])
                {
                    Font = new Font("Oswald Regular", 11, FontStyle.Regular),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Tag = levelCode
                };

                if (LabelImages != null && i < LabelImages.Length && LabelImages[i] != null)
                {
                    lbl.Image = LabelImages[i];
                    lbl.ImageAlign = ContentAlignment.MiddleLeft;
                    lbl.TextImageRelation = TextImageRelation.ImageBeforeText;
                }

                lbl.MouseDown += (s, e) =>
                {
                    DynamicLabelClick?.Invoke(this, new ToolStripLabelEventArgs(lbl));
                    ShowContextMenu(lbl, levelCode);
                };

                ts.Items.Insert(index++, lbl);
            }
        }

        private void ShowContextMenu(ToolStripLabel tsLabel, int parentMenuCode)
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

        private ContextMenuStrip CreateContextMenu(Form parentForm, int parentMenuCode)
        {
            if (ContextMenuCache.TryGetValue(parentMenuCode, out var cachedMenu))
                return cachedMenu;

            ContextMenuStrip contextMenu = new ContextMenuStrip
            {
                Font = new Font("Oswald", 10, FontStyle.Regular)
            };

            DataTable menuTable = MainForm.objDtMenuDetails;
            if (menuTable == null || menuTable.Rows.Count == 0)
                return contextMenu;

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
                if (string.IsNullOrWhiteSpace(item.MenuName))
                    continue;

                ToolStripMenuItem menuItem = new ToolStripMenuItem(item.MenuName);
                menuItem.Click += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(item.FormClass)) return;

                    try
                    {
                        Type formType = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(a => a.GetTypes())
                            .FirstOrDefault(t => t.Name.Equals(item.FormClass, StringComparison.OrdinalIgnoreCase));

                        if (formType == null) return;

                        Form formInstance = (Form)Activator.CreateInstance(formType);

                        var staticFields = typeof(MainForm).GetFields(BindingFlags.Public | BindingFlags.Static);
                        var field = staticFields.FirstOrDefault(f =>
                            f.FieldType == formType ||
                            f.Name.IndexOf(item.FormClass, StringComparison.OrdinalIgnoreCase) >= 0);
                        field?.SetValue(null, formInstance);

                        Form mdiParent = parentForm?.ParentForm ?? parentForm;
                        formInstance.MdiParent = mdiParent;
                        formInstance.Show();
                        formInstance.BringToFront();
                    }
                    catch { /* log error */ }
                };

                contextMenu.Items.Add(menuItem);
            }

            ContextMenuCache[parentMenuCode] = contextMenu;
            return contextMenu;
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
