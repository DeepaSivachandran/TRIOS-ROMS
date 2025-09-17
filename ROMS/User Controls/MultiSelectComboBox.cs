using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class ComboItem
{
    public int Id { get; set; }
    public string Text { get; set; }
    public override string ToString() => Text;
}

public class MultiSelectComboBox : ComboBox
{
    private CheckedListBox _checkListBox;
    private ToolStripDropDown _dropDown;
    private ToolStripControlHost _hostList;
    private ToolStripTextBox _txtSearch;
    private ToolStripButton _btnSelectAll;
    private ToolStripButton _btnClearAll;
    private ToolStrip _bottomBar;
    private List<ComboItem> _allItems = new List<ComboItem>();
    private HashSet<int> _checkedIds = new HashSet<int>();
    private string _placeholder = "Select";

    public MultiSelectComboBox()
    {
        this.DropDownHeight = 1;
        this.DropDownStyle = ComboBoxStyle.DropDown;

        // CheckedListBox
        _checkListBox = new CheckedListBox
        {
            CheckOnClick = true,
            BorderStyle = BorderStyle.None
        };
        _checkListBox.ItemCheck += (s, e) =>
        {
            var item = (ComboItem)_checkListBox.Items[e.Index];
            if (e.NewValue == CheckState.Checked) _checkedIds.Add(item.Id);
            else _checkedIds.Remove(item.Id);
           // UpdateText();
        };

        // Host for CheckedListBox
        _hostList = new ToolStripControlHost(_checkListBox)
        {
            Margin = Padding.Empty,
            Padding = Padding.Empty,
            AutoSize = true
        };

        // Search box (manual placeholder for .NET Framework)
        _txtSearch = new ToolStripTextBox
        {
            AutoSize = false,
            Width = 150,
            ForeColor = Color.Gray,
            Text = "Search..."
        };
        _txtSearch.BackColor = Color.FromArgb(240, 240, 240);
        _txtSearch.BorderStyle = BorderStyle.FixedSingle;
        _txtSearch.GotFocus += (s, e) =>
        {
            if (_txtSearch.Text == "Search...")
            {
                _txtSearch.Text = "";
                _txtSearch.ForeColor = Color.Black;
            }
        };

        _txtSearch.LostFocus += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(_txtSearch.Text))
            {
                _txtSearch.Text = "Search...";
                _txtSearch.ForeColor = Color.Gray;
            }
        };

        _txtSearch.TextChanged += (s, e) =>
        {
            if (_txtSearch.Focused && _txtSearch.ForeColor == Color.Black)
                ApplyFilter(_txtSearch.Text);
        };

        // Select All button
        _btnSelectAll = new ToolStripButton("Select All")
        {
            AutoSize = false,
            Width = 70,
            Height = 25,
            TextAlign = ContentAlignment.MiddleCenter
        };
        _btnSelectAll.Click += (s, e) => SelectAll();
        _btnSelectAll.DisplayStyle = ToolStripItemDisplayStyle.Text;
        _btnSelectAll.BackColor = Color.FromArgb(30, 144, 255); // DodgerBlue
        _btnSelectAll.ForeColor = Color.White;
        _btnSelectAll.Font = new Font("Segoe UI", 8, FontStyle.Bold);
        _btnSelectAll.Margin = new Padding(2, 0, 2, 0);
        // Clear All button
        _btnClearAll = new ToolStripButton("Clear All")
        {
            AutoSize = false,
            Width = 70,
            Height = 25,
            TextAlign = ContentAlignment.MiddleCenter
        };
        _btnClearAll.Click += (s, e) => ClearAll();
        _btnClearAll.DisplayStyle = ToolStripItemDisplayStyle.Text;
        _btnClearAll.BackColor = Color.FromArgb(30, 144, 255); // DodgerBlue
        _btnClearAll.ForeColor = Color.White;
        _btnClearAll.Font = new Font("Segoe UI", 8, FontStyle.Bold);
        _btnClearAll.Margin = new Padding(2, 0, 2, 0);
        // Bottom bar (holds both buttons side by side)
        _bottomBar = new ToolStrip
        {
            Dock = DockStyle.None,
            GripStyle = ToolStripGripStyle.Hidden,
            AutoSize = false,
            Height = 30
        };
        _bottomBar.Items.Add(_btnSelectAll);
        _bottomBar.Items.Add(_btnClearAll);
        _dropDown.RenderMode = ToolStripRenderMode.System; // lighter
        _dropDown.AutoClose = true;
        // Dropdown container
        _dropDown = new ToolStripDropDown { Padding = Padding.Empty };
        _dropDown.Items.Add(_txtSearch);
      //  _dropDown.Items.Add(new ToolStripSeparator());
        _dropDown.Items.Add(_hostList);
     //   _dropDown.Items.Add(new ToolStripSeparator());
        _dropDown.Items.Add(new ToolStripControlHost(_bottomBar));

        this.Click += (s, e) => ShowDropDown();
        this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Down) ShowDropDown(); };

        _dropDown.Closed += (s, e) => this.Focus();
    }

    public void LoadItems(List<ComboItem> items, string placeholder = "Select")
    {
        _allItems = items;
        _checkedIds.Clear();
        _placeholder = placeholder;
        this.Text = placeholder;
        ApplyFilter("");
       // UpdateText();
    }

    private void ShowDropDown()
    {
        if (_allItems.Count == 0) return;

        int width = Math.Max(this.Width, this.DropDownWidth);
        int maxHeight = Math.Min(_checkListBox.PreferredHeight, 250);

        _checkListBox.Width = width;
        _checkListBox.Height = maxHeight;
        _hostList.Size = new Size(width, maxHeight);

        // Remove unnecessary spacing
        _dropDown.Padding = Padding.Empty;
        _dropDown.Margin = Padding.Empty;
        _bottomBar.Padding = Padding.Empty;
        _bottomBar.Margin = Padding.Empty;
        _txtSearch.Padding = Padding.Empty;
        _txtSearch.Margin = Padding.Empty;

        _dropDown.Show(this, new Point(0, this.Height));
        _txtSearch.Focus();
    }

    private void UpdateText()
    {
        if (_checkedIds.Count == 0)
        {
            this.Text = _placeholder;
            return;
        }

        StringBuilder sb = new StringBuilder();
        foreach (var it in _allItems)
        {
            if (_checkedIds.Contains(it.Id))
            {
                if (sb.Length > 0) sb.Append(", ");
                sb.Append(it.Text);
            }
        }
        this.Text = sb.ToString();
    }

    public List<int> CheckedIds => new List<int>(_checkedIds);

    public void ApplyFilter(string searchText)
    {
        _checkListBox.Items.Clear();
        foreach (var it in _allItems)
        {
            if (string.IsNullOrEmpty(searchText) || it.Text.ToLower().Contains(searchText.ToLower()))
            {
                _checkListBox.Items.Add(it, _checkedIds.Contains(it.Id));
            }
        }
    }

    public void ClearAll()
    {
        _checkedIds.Clear();
        for (int i = 0; i < _checkListBox.Items.Count; i++)
            _checkListBox.SetItemChecked(i, false);
       // UpdateText();
    }

    public void SelectAll()
    {
        foreach (var it in _allItems) _checkedIds.Add(it.Id);

        for (int i = 0; i < _checkListBox.Items.Count; i++)
            _checkListBox.SetItemChecked(i, true);

        //UpdateText();
    }
}
