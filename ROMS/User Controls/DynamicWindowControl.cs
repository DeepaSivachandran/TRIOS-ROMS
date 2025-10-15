using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ROMS
{
    [ToolboxItem(true)]
    [DesignerCategory("Code")]
    public class DynamicWindowControl : Component
    {
        public ToolStripLabel MinimizeLabel { get; private set; }
        public ToolStripLabel CloseLabel { get; private set; }

        private ToolStrip _toolStrip;

        public event EventHandler FormMinimizeClicked;
        public event EventHandler FormCloseClicked;

        /// <summary>
        /// Initialize the control on an existing ToolStrip and attach images for minimize/close
        /// </summary>
        public void Initialize(ToolStrip toolStrip)
        {
            if (toolStrip == null) return;
            _toolStrip = toolStrip;

            // --- Minimize Label ---
            MinimizeLabel = new ToolStripLabel()
            {
                Image = Properties.Resources.minimize,
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Margin = new Padding(4, 0, 4, 0),
                Alignment = ToolStripItemAlignment.Right
            };
            MinimizeLabel.Click += (s, e) => FormMinimizeClicked?.Invoke(this, EventArgs.Empty);

            // --- Close Label ---
            CloseLabel = new ToolStripLabel()
            {
                Image = Properties.Resources.close_window,
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Margin = new Padding(4, 0, 4, 0),
                Alignment = ToolStripItemAlignment.Right
            };
            CloseLabel.Click += (s, e) => FormCloseClicked?.Invoke(this, EventArgs.Empty);

            // --- Insert after all existing right-aligned items ---
            // Find the index of the **first right-aligned item**
            int rightStartIndex = _toolStrip.Items.Cast<ToolStripItem>()
                                    .ToList()
                                    .FindIndex(item => item.Alignment == ToolStripItemAlignment.Right);

            if (rightStartIndex == -1)
            {
                // No right-aligned items yet, just add
                _toolStrip.Items.Add(MinimizeLabel);
                _toolStrip.Items.Add(CloseLabel);
            }
            else
            {
                // Insert **at the beginning of right-aligned items**, so they appear at the far right
                _toolStrip.Items.Insert(rightStartIndex, MinimizeLabel);      // last item should be far right
                _toolStrip.Items.Insert(rightStartIndex, CloseLabel);   // before close
            }
        }
    }
}
