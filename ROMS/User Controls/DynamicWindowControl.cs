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
        private Form _parentForm;

        public event EventHandler FormMinimizeClicked;
        public event EventHandler FormCloseClicked;

        /// <summary>
        /// Initialize the control on an existing ToolStrip and attach minimize/close handlers.
        /// </summary>
        public void Initialize(ToolStrip toolStrip, Form parentForm)
        {
            if (toolStrip == null || parentForm == null)
                return;

            _toolStrip = toolStrip;
            _parentForm = parentForm;

            // --- Minimize Label ---
            MinimizeLabel = new ToolStripLabel()
            {
                Image = Properties.Resources.mismatch,
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Margin = new Padding(4, 0, 4, 0),
                Alignment = ToolStripItemAlignment.Right
            };
            MinimizeLabel.Click += MinimizeLabel_Click;

            // --- Close Label ---
            CloseLabel = new ToolStripLabel()
            {
                Image = Properties.Resources.close_Form,
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Margin = new Padding(4, 0, 4, 0),
                Alignment = ToolStripItemAlignment.Right
            };
            CloseLabel.Click += CloseLabel_Click;

            // --- Insert buttons at right ---
            int rightStartIndex = _toolStrip.Items.Cast<ToolStripItem>()
                                    .ToList()
                                    .FindIndex(item => item.Alignment == ToolStripItemAlignment.Right);

            if (rightStartIndex == -1)
            {
                _toolStrip.Items.Add(MinimizeLabel);
                _toolStrip.Items.Add(CloseLabel);
            }
            else
            {
                _toolStrip.Items.Insert(rightStartIndex, MinimizeLabel);
                _toolStrip.Items.Insert(rightStartIndex, CloseLabel);
            }
        }

        private void MinimizeLabel_Click(object sender, EventArgs e)
        {
            FormMinimizeClicked?.Invoke(this, EventArgs.Empty);

            if (_parentForm == null) return;

            _parentForm.WindowState = FormWindowState.Minimized;

            if (_parentForm.MdiParent is MainForm mainForm)
            {
                mainForm.Invoke(new Action(() =>
                {
                    mainForm.SubForm_Resize(_parentForm, EventArgs.Empty);
                }));
            }
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            FormCloseClicked?.Invoke(this, EventArgs.Empty);

            if (_parentForm == null) return;

            if (_parentForm.MdiParent is MainForm mainForm)
            {
                mainForm.Invoke(new Action(() =>
                {
                    mainForm.PrepareFormClose(_parentForm, _parentForm.Name);
                }));
            }
        }
    }
}
