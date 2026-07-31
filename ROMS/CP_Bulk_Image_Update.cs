using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ROMS
{
    //Created By:Sathish ; Created On:-11/08/2023
    public partial class CP_Bulk_Image_Update : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();

        private ToolTip tpGroup = new ToolTip();
        private ToolTip tpSubgroup = new ToolTip();
        DataTable dtSubGroup;
        DataTable dtProducts;
        public int varUpDownKeyGroup, varUpDownKeySubGroup = 0;
        DataTable dtSubgroupImages = new DataTable();


        private List<string> imagePaths = new List<string>();
        public class EditableImage
        {
            public string FilePath { get; set; }
            public Bitmap EditedImage { get; set; }
            public PictureBox Thumbnail { get; set; }
            public Panel ContainerPanel { get; set; }
            public int RotationAngle { get; set; } = 0;
        }
        private List<EditableImage> editableImages = new List<EditableImage>();
        private Image originalImage;
        private float zoom = 1.0f;
        private bool cropMode = false;
        private Rectangle cropRect;


        public CP_Bulk_Image_Update()
        {
            InitializeComponent();
            windowControl.Initialize(tsImageList, this);
        }
        private void CP_Bulk_Image_Updatelist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    windowControl?.TriggerClose();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_Bulk_Image_Updatelist_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 50513;
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                dtSubgroupImages.TableName = "MR_Subgroup_Images";
                dtSubgroupImages.Columns.Add("SGI_PRID", typeof(int));
                dtSubgroupImages.Columns.Add("SGI_ImageName", typeof(string));
                LoadProducts();
                this.ActiveControl = txtGroup;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LoadProducts()
        {
            SPDataService objspdservice = new SPDataService();

            DataSet ds = objspdservice.udfnSubGroupList(
                            20,
                            0,
                            "",
                            0,
                            0,
                            "",
                            0,
                            0,
                            0,
                            0,
                            0,0);

            objspdservice.CloseConnection();

            dtProducts = ds.Tables[0];
        }
        public void udfnList()
        {
            try
            {
                epBulkImage.Clear();
                lblActiveProCount.Text = "0";
                lblImageUploadedCount.Text = "0";
                lblImageApprovedCount.Text = "0";
                lblImageUnapprovedCount.Text = "0";
                int varGroupID = 0, varSubgroupID = 0;
                if (txtGroup.Text.Trim() == "")
                {
                    epBulkImage.SetError(txtGroup, "Please enter group name");
                    txtGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroup.ShowAlways = true;
                    tpGroup.Show("Please enter group name", txtGroup, 5000);
                    return;
                }
                else
                {
                    if (lblGroup.Text == "0" || lblGroup.Text == "")
                    {
                        epBulkImage.SetError(txtGroup, "Please enter valid group name");
                        txtGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpGroup.ShowAlways = true;
                        tpGroup.Show("Please enter valid group name", txtGroup, 5000);
                        return;
                    }
                    varGroupID = Convert.ToInt32(lblGroupCode.Text);
                }
                if (txtSubGroup.Text.Trim() == "")
                {
                    epBulkImage.SetError(txtSubGroup, "Please enter subgroup name");
                    txtSubGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSubgroup.ShowAlways = true;
                    tpSubgroup.Show("Please enter subgroup name", txtSubGroup, 5000);
                    return;
                }
                else
                {
                    if (lblSubGroupCode.Text == "0" || lblSubGroupCode.Text == "")
                    {
                        epBulkImage.SetError(txtSubGroup, "Please enter valid subgroup name");
                        txtSubGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSubgroup.ShowAlways = true;
                        tpSubgroup.Show("Please enter valid subgroup name", txtSubGroup, 5000);
                        return;
                    }
                    varSubgroupID = Convert.ToInt32(lblSubGroupCode.Text);
                }
                grdSubgroups.Rows.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objspdservice.udfnSubGroupList(19, varSubgroupID, "", varGroupID, 0, "", 0, 0, 0, 0, 0,0);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grdSubgroups.Rows.Clear();
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                grdSubgroups.Rows.Add(false, objDs.Tables[0].Rows[i]["PI Code"].ToString(), objDs.Tables[0].Rows[i]["Product"].ToString(), objDs.Tables[0].Rows[i]["ImageFlag"].ToString(), objDs.Tables[0].Rows[i]["ImageApprovedFlag"].ToString(),  objDs.Tables[0].Rows[i]["SGID"].ToString(),  objDs.Tables[0].Rows[i]["PRID"].ToString(),  objDs.Tables[0].Rows[i]["IsMapped"].ToString());

                                DataGridViewRow gridRow = grdSubgroups.Rows[grdSubgroups.Rows.Count - 1];

                                string imageFlag = Convert.ToString(gridRow.Cells["clmImageUpload"].Value);
                                string imageApprovedFlag = Convert.ToString(gridRow.Cells["clmImageApproved"].Value);

                                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)gridRow.Cells["clmCheck"];
                                DataGridViewCell viewCell = gridRow.Cells["clmView"];

                                if (imageFlag == "Yes")
                                {
                                    viewCell.ReadOnly = false;
                                    viewCell.Style.BackColor = Color.White;
                                    viewCell.Style.SelectionBackColor = grdSubgroups.DefaultCellStyle.SelectionBackColor;
                                }
                                else
                                {
                                    viewCell.ReadOnly = true;
                                    viewCell.Style.BackColor = Color.LightGray;
                                    viewCell.Style.SelectionBackColor = Color.LightGray;
                                }

                                if (imageFlag == "Yes" && imageApprovedFlag == "No")
                                {
                                    chk.Value = false;
                                    chk.ReadOnly = true;

                                    chk.Style.BackColor = Color.LightGray;
                                    chk.Style.SelectionBackColor = Color.LightGray;
                                }
                                else
                                {
                                    chk.ReadOnly = false;
                                }
                            }
                            lblActiveProCount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ActiveProCount"].ToString());
                            lblImageUploadedCount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ImageUploadCount"].ToString());
                            lblImageApprovedCount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ImageApprovedCount"].ToString());
                            lblImageUnapprovedCount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ImageUnapprovedCount"].ToString());

                            grdSubgroups.ClearSelection();
                            grdSubgroups.Columns["clmImageUpload"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdSubgroups.Columns["clmImageApproved"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        //private void LoadTreeView()
        //{
        //    try
        //    {
        //        tvSubgroupProducts.BeginUpdate();
        //        tvSubgroupProducts.Nodes.Clear();

        //        SPDataService objspdservice = new SPDataService();

        //        DataSet ds = objspdservice.udfnSubGroupList(20, 0, "", 0, 0, "", 0, 0, 0, 0, 0);

        //        objspdservice.CloseConnection();

        //        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        //            return;

        //        BindTree(ds.Tables[0]);

        //        tvSubgroupProducts.CollapseAll();
        //        if (tvSubgroupProducts.Nodes.Count > 0)
        //        {
        //            tvSubgroupProducts.Nodes[0].EnsureVisible();
        //            tvSubgroupProducts.TopNode = tvSubgroupProducts.Nodes[0];
        //        }
        //        tvSubgroupProducts.EndUpdate();
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}
        //private void BindTree(DataTable dt)
        //{
        //    tvSubgroupProducts.Nodes.Clear();

        //    tvSubgroupProducts.ImageList = imageList1;

        //    Dictionary<int, TreeNode> groups = new Dictionary<int, TreeNode>();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        int subgroupID = Convert.ToInt32(row["PR_PRSGID"]);
        //        string subgroup = row["Subgroup"].ToString();
        //        string product = row["Product"].ToString();

        //        TreeNode parentNode;

        //        if (!groups.ContainsKey(subgroupID))
        //        {
        //            parentNode = new TreeNode(subgroup);

        //            parentNode.Tag = subgroupID;

        //            parentNode.ImageKey = "Folder.png";
        //            parentNode.SelectedImageKey = "Folder.png";

        //            groups.Add(subgroupID, parentNode);

        //            tvSubgroupProducts.Nodes.Add(parentNode);
        //        }
        //        else
        //        {
        //            parentNode = groups[subgroupID];
        //        }

        //        TreeNode child = new TreeNode(product);

        //        child.Tag = subgroupID;

        //        child.ImageKey = "Product.png";
        //        child.SelectedImageKey = "Product.png";

        //        parentNode.Nodes.Add(child);
        //    }

        //    tvSubgroupProducts.CollapseAll();
        //}
        private void grdSubgroups_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (grdSubgroups.Columns[e.ColumnIndex].Name == "clmProduct")
                {
                    //e.Value = "▶ " + e.Value + " Products";
                    //e.FormattingApplied = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                grdSubgroups.ClearSelection();
                bool isProductSelected = grdSubgroups.Rows.Cast<DataGridViewRow>()
                    .Any(r => Convert.ToBoolean(r.Cells["clmCheck"].Value));
                if (!isProductSelected)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(80);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                udfnSave();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSave()
        {
            try
            {
                btnSave.Enabled = false;
                string varResult = ""; string varOriginator = "Product Sub Group Image Mapping";
                List<string> imageNameList = new List<string>();

                DataService objdser = new DataService();
                string destinationPath = objdser.displaydata("SELECT TOP 1 image_path FROM DEF_SharedFolderPath ORDER BY SFID DESC");
                objdser.CloseConnection();

                string destinationFolder = Path.GetDirectoryName(destinationPath);
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }
                List<(int ProductID, string ProductCode)> selectedProducts = new List<(int, string)>();
                foreach (DataGridViewRow row in grdSubgroups.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["clmCheck"].Value))
                    {
                        selectedProducts.Add
                        (
                            (
                                Convert.ToInt32(row.Cells["clmPRID"].Value),
                                row.Cells["clmPICode"].Value.ToString()
                            )
                        );
                    }
                }
                if (selectedProducts.Count == 0)
                {
                    MessageBox.Show("Please select atleast  one product!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Save images for every selected product
                //foreach (var product in selectedProducts)
                //{
                //    int imageNo = 1;

                //    // Delete existing images of this product
                //    string[] existingFiles = Directory.GetFiles(destinationPath, product.ProductCode + "_*");

                //    foreach (string file in existingFiles)
                //    {
                //        if (File.Exists(file))
                //        {
                //            File.SetAttributes(file, FileAttributes.Normal);

                //            pictureBox1.Image?.Dispose();
                //            pictureBox1.Image = null;

                //            originalImage?.Dispose();
                //            originalImage = null;

                //            GC.Collect();
                //            GC.WaitForPendingFinalizers();

                //            File.Delete(file);
                //        }
                //    }

                //    foreach (var ei in editableImages)
                //    {
                //        string extensionName = Path.GetExtension(ei.FilePath);

                //        string imageName = $"{product.ProductCode}_{imageNo}{extensionName}";

                //        string destinationFile = Path.Combine(destinationPath, imageName);

                //        if (ei.EditedImage != null)
                //        {
                //            if (File.Exists(destinationFile))
                //            {
                //                File.SetAttributes(destinationFile, FileAttributes.Normal);

                //                pictureBox1.Image?.Dispose();
                //                pictureBox1.Image = null;

                //                originalImage?.Dispose();
                //                originalImage = null;

                //                GC.Collect();
                //                GC.WaitForPendingFinalizers();

                //                File.Delete(destinationFile);
                //            }

                //            using (MemoryStream ms = new MemoryStream())
                //            {
                //                ei.EditedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //                File.WriteAllBytes(destinationFile, ms.ToArray());
                //            }
                //        }
                //        else
                //        {
                //            if (ei.FilePath != destinationFile)
                //            {
                //                if (File.Exists(destinationFile))
                //                {
                //                    File.SetAttributes(destinationFile, FileAttributes.Normal);

                //                    pictureBox1.Image?.Dispose();
                //                    pictureBox1.Image = null;

                //                    originalImage?.Dispose();
                //                    originalImage = null;

                //                    GC.Collect();
                //                    GC.WaitForPendingFinalizers();

                //                    File.Delete(destinationFile);
                //                }

                //                using (FileStream sourceStream = new FileStream(ei.FilePath, FileMode.Open, FileAccess.Read))
                //                using (FileStream destStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
                //                {
                //                    sourceStream.CopyTo(destStream);
                //                }
                //            }
                //        }

                //        // Add one record to UDTT
                //        dtSubgroupImages.Rows.Add(product.ProductID, imageName);

                //        imageNo++;
                //    }
                //}

                foreach (var ei in editableImages)
                {
                    // Keep the original file name
                    string imageName = Path.GetFileName(ei.FilePath);

                    string destinationFile = Path.Combine(destinationPath, imageName);

                    // Save only if it doesn't already exist
                    if (!File.Exists(destinationFile))
                    {
                        if (ei.EditedImage != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                ei.EditedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                File.WriteAllBytes(destinationFile, ms.ToArray());
                            }
                        }
                        else
                        {
                            using (FileStream sourceStream = new FileStream(ei.FilePath, FileMode.Open, FileAccess.Read))
                            using (FileStream destStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
                            {
                                sourceStream.CopyTo(destStream);
                            }
                        }
                    }

                    // Store the image name
                    imageNameList.Add(imageName);
                }

                //============================
                // Map every image to every selected product
                //============================
                foreach (var product in selectedProducts)
                {
                    foreach (string imageName in imageNameList)
                    {
                        dtSubgroupImages.Rows.Add(product.ProductID, imageName);
                    }
                }
                SPDataService objDser = new SPDataService();
                if (grdSubgroups.Rows.Count > 0)
                {
                    varResult = objDser.udfnSubGroup(3, Convert.ToInt32(lblSubGroupCode.Text), 0, "", "", 0, 0, 0, 0, varOriginator, "", MainForm.pbUserID, 0, 0, 0, "", "", 0, 0, dtSubgroupImages);
                    objDser.CloseConnection();
                    btnSave.Enabled = true;
                    if (varResult.Split('~')[0] == "3")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        windowControl?.TriggerClose();
                    }
                    else if (varResult.Split('~')[0] == "4")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnSave.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Focus();
                btnSave.Enabled = true;
            }
        }
        private void ClearAllImages()
        {
            try
            {
                // Remove thumbnail images
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    if (ctrl is Panel pnl)
                    {
                        foreach (Control c in pnl.Controls)
                        {
                            if (c is PictureBox pb)
                            {
                                pb.Image?.Dispose();
                                pb.Image = null;
                            }
                        }

                        pnl.Dispose();
                    }
                }

                flowLayoutPanel1.Controls.Clear();

                // Clear collections
                imagePaths.Clear();

                foreach (var img in editableImages)
                {
                    img.EditedImage?.Dispose();
                    img.EditedImage = null;
                }

                editableImages.Clear();

                // Clear editor image
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                if (originalImage != null)
                {
                    originalImage.Dispose();
                    originalImage = null;
                }

                currentImage = null;

                // Reset variables
                zoom = 1.0f;
                cropMode = false;
                cropRect = Rectangle.Empty;

                // Reset TrackBars
                tbBrightness.Value = 0;
                tbContrast.Value = 0;
                tbSaturation.Value = 0;

                // Hide colour panel
                pnlControls.Visible = false;

                // Reset PictureBox
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Size = pnlImageContainer.ClientSize;
                pictureBox1.Location = new Point(0, 0);

                // Hide editing buttons
                UpdateZoomButtonsVisibility();

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                udfnList();
                //if (flowLayoutPanel1.Controls.Count != 0)
                //{
                //    SPDataService objDServ = new SPDataService();
                //    string varMessage = objDServ.udfnGetMessages(234);
                //    objDServ.CloseConnection();
                //    //DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    if (dialogResult == DialogResult.OK)
                //    {
                //        ClearAllImages();
                //        udfnList();
                //    }
                //    else
                //    {
                //        return;
                //    }
                //}
                //else
                //{
                //    udfnList();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSubgroup.Visible = false;
                DGV_FilterSubgroup.DataSource = null;
                txtGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyGroup = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterGroup.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterGroup.Visible == false)
                {
                    txtSubGroup.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterGroup.Focus();
                }
                if (DGV_FilterGroup.CurrentCell == null && DGV_FilterGroup.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterGroup.Focus();
                    int RowIndex = DGV_FilterGroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterGroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyGroup = 1;
                    }
                    else
                    {
                        varUpDownKeyGroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }
                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterGroup.Rows.Count) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterGroup.Rows.Count))
                            {
                                txtGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }

                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterGroup.Rows.Count > 0)
                                {
                                    varUpDownKeyGroup = 1;
                                    udfnGroupAutocomplete();
                                    DGV_FilterGroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtGroup.Focus();
                    //txtGroup.SelectionStart = txtGroup.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtSubGroup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyGroup == 0)
                {
                    txtSubGroup.Text = "";
                    lblSubGroupCode.Text = "0";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtGroup.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnGroupList(7, 0, 0, txtGroup.Text, 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterGroup.Visible = true;
                                    DGV_FilterGroup.DataSource = objDs.Tables[0];
                                    DGV_FilterGroup.Columns["PRGID"].Visible = false;
                                    DGV_FilterGroup.Columns["PRG_EName"].HeaderText = "Group English Name";
                                    DGV_FilterGroup.Columns["PRG_TName"].HeaderText = "Group Tamil Name";
                                    DGV_FilterGroup.Columns["PRG_EName"].Width = 130;
                                    DGV_FilterGroup.Columns["PRG_TName"].Width = 130;
                                    DGV_FilterGroup.Columns["PRG_EName"].DisplayIndex = 0;
                                    DGV_FilterGroup.Columns["PRG_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterGroup.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterGroup.Visible = false;
                                    DGV_FilterGroup.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterGroup.Visible = false;
                                DGV_FilterGroup.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterGroup.Visible = false;
                            DGV_FilterGroup.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterGroup.Visible = false;
                        DGV_FilterGroup.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyGroup = 1;
                udfnGroupAutocomplete();
                txtSubGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterGroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterGroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyGroup = 1;
                    }
                    else
                    {
                        varUpDownKeyGroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            txtGroup.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRG_EName"].Value.ToString();

                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterGroup.Rows.Count) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterGroup.Rows.Count))
                            {
                                txtGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }

                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterGroup.Rows.Count > 0)
                                {
                                    varUpDownKeyGroup = 1;
                                    udfnGroupAutocomplete();
                                    DGV_FilterGroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtSubGroup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnGroupAutocomplete()
        {
            try
            {
                if (txtGroup.Text.Trim() != "")
                {
                    lblGroupCode.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRGID"].Value.ToString();
                    txtGroup.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRG_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtSubGroup.Focus();
            }
        }

        private void txtSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeySubGroup = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterSubgroup.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterSubgroup.Visible == false)
                {
                    btnView.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterSubgroup.Focus();
                }
                if (DGV_FilterSubgroup.CurrentCell == null && DGV_FilterSubgroup.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterSubgroup.Focus();
                    int RowIndex = DGV_FilterSubgroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSubgroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySubGroup = 1;
                    }
                    else
                    {
                        varUpDownKeySubGroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }
                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSubgroup.Rows.Count) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSubgroup.Rows.Count))
                            {
                                txtSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }

                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSubgroup.Rows.Count > 0)
                                {
                                    varUpDownKeySubGroup = 1;
                                    udfnSubGroupAutocomplete();
                                    DGV_FilterSubgroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtSubGroup.Focus();
                    //txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnView.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSubGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeySubGroup == 0)
                {
                    if (txtGroup.Text.Trim() == "")
                    {
                        lblGroupCode.Text = "0";
                    }

                    //lvSubGroup.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtSubGroup.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnSubGroupList(9, 0, "", Convert.ToInt32(lblGroupCode.Text), 0, txtSubGroup.Text, 0, 0, 0, 0, 0,0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterSubgroup.Visible = true;
                                    DGV_FilterSubgroup.DataSource = objDs.Tables[0];
                                    DGV_FilterSubgroup.Columns["PRSGID"].Visible = false;
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].HeaderText = "Subgroup English Name";
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].HeaderText = "Subgroup Tamil Name";
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].Width = 150;
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].Width = 200;
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].DisplayIndex = 0;
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterSubgroup.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterSubgroup.Visible = false;
                                    DGV_FilterSubgroup.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterSubgroup.Visible = false;
                                DGV_FilterSubgroup.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterSubgroup.Visible = false;
                            DGV_FilterSubgroup.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterSubgroup.Visible = false;
                        DGV_FilterSubgroup.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterSubgroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeySubGroup = 1;
                udfnSubGroupAutocomplete();
                btnView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterSubgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterSubgroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSubgroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySubGroup = 1;
                    }
                    else
                    {
                        varUpDownKeySubGroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            txtSubGroup.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSG_EName"].Value.ToString();

                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSubgroup.Rows.Count) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSubgroup.Rows.Count))
                            {
                                txtSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }

                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSubgroup.Rows.Count > 0)
                                {
                                    varUpDownKeySubGroup = 1;
                                    udfnSubGroupAutocomplete();
                                    DGV_FilterSubgroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnView.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSubGroupAutocomplete()
        {
            try
            {
                if (txtSubGroup.Text.Trim() != "")
                {
                    lblSubGroupCode.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSGID"].Value.ToString();
                    txtSubGroup.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSG_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnView.Focus();
            }
        }

        private void tsbBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = true;  // Allow multiple selection
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        int varUploadFlag = 0;
                        foreach (string file in ofd.FileNames)
                        {
                            FileInfo fileInfo = new FileInfo(file);

                            if (fileInfo.Length > 512000) // 500KB limit
                            {
                                varUploadFlag++;
                                continue; // Skip this file
                            }
                        }
                        if (varUploadFlag == 0)
                        {
                            foreach (string file in ofd.FileNames)
                            {
                                FileInfo fileInfo = new FileInfo(file);

                                if (fileInfo.Length > 512000) // 500KB limit
                                {
                                    MessageBox.Show($"The file '{fileInfo.Name}' is too large. Please select an image below 500KB.",
                                                    "File Size Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    continue; // Skip this file
                                }
                                else
                                {
                                    if (!imagePaths.Contains(file))  // Avoid duplicate images
                                    {
                                        imagePaths.Add(file);
                                        AddImageToPanel(file);
                                        if (imagePaths.Count == 1)
                                        {
                                            ZoomImage(file);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show($"The file is too large. Please select an image below 500KB.",
                                                  "File Size Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void AddImageToPanel(string filePath)
        {
            try
            {
                Panel panel = new Panel
                {
                    Size = new Size(120, 150),
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10)
                };

                PictureBox pictureBox = new PictureBox
                {
                    Image = LoadImageWithoutLock(filePath),
                    ImageLocation = filePath,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(100, 100),
                    Dock = DockStyle.Top,
                    Cursor = Cursors.Hand
                };

                Button btnRemove = new Button
                {
                    Text = "X",
                    ForeColor = Color.White,
                    BackColor = Color.Red,
                    Font = new Font("Arial", 8, FontStyle.Bold),
                    Width = 20,
                    Height = 20,
                    Cursor = Cursors.Hand
                };
                btnRemove.Click += (s, e) => RemoveImage(panel, filePath);

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(btnRemove);
                btnRemove.Location = new Point(100, 0);
                btnRemove.BringToFront();
                flowLayoutPanel1.Controls.Add(panel);
                flowLayoutPanel1.AutoScroll = true;
                EditableImage ei = new EditableImage
                {
                    FilePath = filePath,
                    EditedImage = null,
                    Thumbnail = pictureBox,
                    ContainerPanel = panel
                };
                editableImages.Add(ei);
                pictureBox.Click += (s, e) =>
                {
                    LoadImageToEditor(ei);
                };
                if (currentImage == null)
                {
                    LoadImageToEditor(ei);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        EditableImage currentImage;
        private void ZoomImage(string path)
        {
            try
            {
                tsbCropImage.Enabled = false;
                if (originalImage != null)
                    originalImage.Dispose();

                originalImage = LoadImageWithoutLock(path);
                zoom = 1.0f;

                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = new Bitmap(originalImage);
                pictureBox1.Size = pnlImageContainer.ClientSize;
                pictureBox1.Location = new Point(
                    Math.Max((pnlImageContainer.Width - pictureBox1.Width) / 2, 0),
                    Math.Max((pnlImageContainer.Height - pictureBox1.Height) / 2, 0)
                );
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private Image LoadImageWithoutLock(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (Image img = Image.FromStream(fs))
                {
                    return new Bitmap(img);
                }
            }
        }
        private void LoadImageToEditor(EditableImage ei)
        {
            currentImage = ei;

            if (ei.EditedImage != null)
            {
                originalImage = new Bitmap(ei.EditedImage);
            }
            else
            {
                using (FileStream fs = new FileStream(ei.FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (Image temp = Image.FromStream(fs))
                    {
                        originalImage = new Bitmap(temp);
                    }
                }
            }

            zoom = 1.0f;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = new Bitmap(originalImage);
            pictureBox1.Size = pnlImageContainer.ClientSize;
            pictureBox1.Location = new Point(0, 0);
            UpdateZoomButtonsVisibility();
        }
        private void UpdateZoomButtonsVisibility()
        {
            bool hasImage = pictureBox1.Image != null;
            tsbZoomIn.Visible = hasImage;
            tsbZoomOut.Visible = hasImage;
            tsbRotateR.Visible = hasImage;
            tsbRotateL.Visible = hasImage;
            tsbCrop.Visible = hasImage;
            tsbColour.Visible = hasImage;
            tsbCropImage.Visible = hasImage;
            tsbReset.Visible = hasImage;
            tssEdit.Visible = hasImage;
            toolStripSeparator1.Visible = hasImage;
            toolStripSeparator2.Visible = hasImage;
            toolStripSeparator3.Visible = hasImage;
            toolStripSeparator4.Visible = hasImage;
            toolStripSeparator5.Visible = hasImage;
        }
        private void RemoveImage(Panel panel, string imagePath)
        {
            try
            {
                EditableImage toRemove = editableImages.FirstOrDefault(ei => ei.FilePath == imagePath && ei.ContainerPanel == panel);
                if (toRemove != null)
                {
                    editableImages.Remove(toRemove);
                }
                flowLayoutPanel1.Controls.Remove(panel);
                panel.Dispose();

                if (currentImage != null && currentImage.FilePath == imagePath)
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }

                    if (originalImage != null)
                    {
                        originalImage.Dispose();
                        originalImage = null;
                    }

                    currentImage = null;
                    zoom = 1.0f;
                }
                UpdateZoomButtonsVisibility();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbColour_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnlControls.Visible == true)
                {
                    pnlControls.Visible = false;
                }
                else
                {
                    tbBrightness.Value = 0;
                    tbContrast.Value = 0;
                    tbSaturation.Value = 0;
                    pnlControls.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbCrop_Click(object sender, EventArgs e)
        {
            try
            {
                tsbCropImage.Visible = true;
                tsbCropImage.Enabled = true;
                cropMode = true;
                cropRect = new Rectangle(
                    0, 0,
                    pictureBox1.Width,
                    pictureBox1.Height
                );

                pictureBox1.Invalidate();
                UpdateZoomButtonsVisibility();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbCropImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cropMode || pictureBox1.Image == null) return;

                float scaleX = (float)originalImage.Width / pictureBox1.Width;
                float scaleY = (float)originalImage.Height / pictureBox1.Height;

                Rectangle actualRect = new Rectangle(
                    (int)(cropRect.X * scaleX),
                    (int)(cropRect.Y * scaleY),
                    (int)(cropRect.Width * scaleX),
                    (int)(cropRect.Height * scaleY)
                );

                if (actualRect.X < 0) actualRect.X = 0;
                if (actualRect.Y < 0) actualRect.Y = 0;
                if (actualRect.X + actualRect.Width > originalImage.Width)
                    actualRect.Width = originalImage.Width - actualRect.X;
                if (actualRect.Y + actualRect.Height > originalImage.Height)
                    actualRect.Height = originalImage.Height - actualRect.Y;

                if (actualRect.Width <= 0 || actualRect.Height <= 0)
                {
                    //MessageBox.Show("Invalid crop area!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap bmp = new Bitmap(originalImage);
                Bitmap cropped = bmp.Clone(actualRect, bmp.PixelFormat);

                pictureBox1.Image = cropped;
                originalImage = cropped;

                if (currentImage != null)
                {
                    currentImage.EditedImage = new Bitmap(cropped);
                }
                zoom = 1.0f;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Size = pnlImageContainer.ClientSize;
                pictureBox1.Location = new Point(
                    Math.Max((pnlImageContainer.Width - pictureBox1.Width) / 2, 0),
                    Math.Max((pnlImageContainer.Height - pictureBox1.Height) / 2, 0)
                );

                cropMode = false;
                pictureBox1.Invalidate();
                tsbCropImage.Enabled = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbZoomIn_Click(object sender, EventArgs e)
        {
            try
            {
                zoom += 0.1f;
                udfnApplyZoom();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbZoomOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (zoom > 0.2f)
                {
                    zoom -= 0.1f;
                    udfnApplyZoom();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnApplyZoom()
        {
            try
            {
                if (originalImage == null) return;

                int newWidth = (int)(originalImage.Width * zoom);
                int newHeight = (int)(originalImage.Height * zoom);

                pictureBox1.Size = new Size(newWidth, newHeight);
                pictureBox1.Image = new Bitmap(originalImage, new Size(newWidth, newHeight));

                pnlImageContainer.AutoScroll = false;

                if (newWidth <= pnlImageContainer.ClientSize.Width &&
                    newHeight <= pnlImageContainer.ClientSize.Height)
                {
                    pictureBox1.Location = new Point(
                        (pnlImageContainer.ClientSize.Width - newWidth) / 2,
                        (pnlImageContainer.ClientSize.Height - newHeight) / 2
                    );
                }
                else
                {
                    pnlImageContainer.AutoScroll = true;
                    pictureBox1.Location = new Point(0, 0);
                }

                pictureBox1.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsbRotateL_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null) return;

                //Bitmap bmp = new Bitmap(originalImage);
                //bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);

                //pictureBox1.Image?.Dispose();
                //pictureBox1.Image = new Bitmap(bmp);
                using (Bitmap bmp = new Bitmap(originalImage))  // safely clone original
                {
                    bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);

                    // Dispose previous pictureBox image
                    pictureBox1.Image?.Dispose();

                    // Clone to avoid file lock or GDI+ issues
                    pictureBox1.Image = new Bitmap(bmp);
                }
                originalImage.Dispose();
                originalImage = new Bitmap(pictureBox1.Image);
                if (currentImage != null)
                {
                    currentImage.EditedImage?.Dispose();
                    currentImage.EditedImage = new Bitmap(pictureBox1.Image);
                }
                zoom = 1.0f;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Size = pnlImageContainer.ClientSize;
                pictureBox1.Location = new Point(
                    Math.Max((pnlImageContainer.Width - pictureBox1.Width) / 2, 0),
                    Math.Max((pnlImageContainer.Height - pictureBox1.Height) / 2, 0)
                );
                currentImage.RotationAngle = (currentImage.RotationAngle + 270) % 360;
                pictureBox1.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbRotateR_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null) return;

                //Bitmap bmp = new Bitmap(originalImage);
                //bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);

                //pictureBox1.Image?.Dispose();
                //pictureBox1.Image = new Bitmap(bmp);
                using (Bitmap bmp = new Bitmap(originalImage))  // safely clone original
                {
                    bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    // Dispose previous pictureBox image
                    pictureBox1.Image?.Dispose();

                    // Clone to avoid file lock or GDI+ issues
                    pictureBox1.Image = new Bitmap(bmp);
                }
                originalImage?.Dispose();
                originalImage = new Bitmap(pictureBox1.Image);
                if (currentImage != null)
                {
                    currentImage.EditedImage?.Dispose();
                    currentImage.EditedImage = new Bitmap(pictureBox1.Image);
                }
                zoom = 1.0f;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Size = pnlImageContainer.ClientSize;
                pictureBox1.Location = new Point(
                    Math.Max((pnlImageContainer.Width - pictureBox1.Width) / 2, 0),
                    Math.Max((pnlImageContainer.Height - pictureBox1.Height) / 2, 0)
                );
                currentImage.RotationAngle = (currentImage.RotationAngle + 90) % 360;
                pictureBox1.Invalidate();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentImage == null || string.IsNullOrEmpty(currentImage.FilePath))
                    return;
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                if (originalImage != null)
                {
                    originalImage.Dispose();
                    originalImage = null;
                }
                originalImage = Image.FromFile(currentImage.FilePath);
                pictureBox1.Image = new Bitmap(originalImage);
                zoom = 1.0f;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Size = pnlImageContainer.ClientSize;

                pictureBox1.Location = new Point(
                    Math.Max((pnlImageContainer.ClientSize.Width - pictureBox1.Width) / 2, 0),
                    Math.Max((pnlImageContainer.ClientSize.Height - pictureBox1.Height) / 2, 0)
                );
                cropMode = false;
                cropRect = Rectangle.Empty;
                if (currentImage.EditedImage != null)
                {
                    currentImage.EditedImage.Dispose();
                    currentImage.EditedImage = null;
                }
                currentImage.RotationAngle = 0;
                tbBrightness.Value = 0;
                tbContrast.Value = 0;
                tbSaturation.Value = 0;
                pictureBox1.Invalidate();
                UpdateZoomButtonsVisibility();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tbBrightness_Scroll(object sender, EventArgs e)
        {
            try
            {
                ApplyAllAdjustments();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tbContrast_Scroll(object sender, EventArgs e)
        {
            try
            {
                ApplyAllAdjustments();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tbSaturation_Scroll(object sender, EventArgs e)
        {
            try
            {
                ApplyAllAdjustments();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ApplyAllAdjustments()
        {
            if (originalImage == null)
                return;

            float brightness = tbBrightness.Value / 100.0f;
            float contrast = (100.0f + tbContrast.Value) / 100.0f;
            contrast *= contrast;
            float saturation = (100.0f + tbSaturation.Value) / 100.0f;

            float lumR = 0.3086f;
            float lumG = 0.6094f;
            float lumB = 0.0820f;

            float sr = (1 - saturation) * lumR;
            float sg = (1 - saturation) * lumG;
            float sb = (1 - saturation) * lumB;

            float[][] colorMatrixElements = {
                                            new float[] { sr + saturation * contrast, sg, sb, 0, 0 },
                                            new float[] { sr, sg + saturation * contrast, sb, 0, 0 },
                                            new float[] { sr, sg, sb + saturation * contrast, 0, 0 },
                                            new float[] { 0, 0, 0, 1, 0 },
                                            new float[] {
                                                        brightness + (0.5f * (1.0f - contrast)),
                                                        brightness + (0.5f * (1.0f - contrast)),
                                                        brightness + (0.5f * (1.0f - contrast)),
                                                        0, 1
                                                        }
                                            };

            Bitmap adjustedBitmap = new Bitmap(originalImage.Width, originalImage.Height);
            using (Graphics g = Graphics.FromImage(adjustedBitmap))
            {
                ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(originalImage,
                    new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    0, 0, originalImage.Width, originalImage.Height,
                    GraphicsUnit.Pixel, attributes);
            }

            pictureBox1.Image = adjustedBitmap;
            if (currentImage != null)
            {
                currentImage.EditedImage?.Dispose();
                currentImage.EditedImage = new Bitmap(adjustedBitmap);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnClose();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    MainForm objMainForm = new MainForm();
                    objMainForm.udfnCloseChildForms();
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdSubgroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdSubgroups.Columns[e.ColumnIndex].Name)
                    {
                        case "clmView":
                            try
                            {
                                if (grdSubgroups.SelectedRows.Count > 0)
                                {
                                    if (grdSubgroups.Columns[e.ColumnIndex].Name == "clmView")
                                    {
                                        string imageFlag = Convert.ToString(grdSubgroups.Rows[e.RowIndex].Cells["clmImageUpload"].Value);

                                        if (imageFlag != "Yes")
                                            return;

                                        int varPRID = Convert.ToInt32(grdSubgroups.SelectedRows[0].Cells["clmPRID"].Value.ToString());
                                        try
                                        {
                                            MainForm.objProductDetails = new ProductDetails();
                                            MainForm.objProductDetails.varProductCode = varPRID;
                                            MainForm.objProductDetails.ShowDialog();
                                        }
                                        catch (Exception ex)
                                        {
                                            objError = new DataError();
                                            objError.WriteFile(ex);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                objError = new DataError();
                                objError.WriteFile(ex);
                            }
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnGridNull(Control skipControl)
        {
            try
            {
                if (skipControl != txtGroup)
                {
                    varUpDownKeyGroup = 0;
                    DGV_FilterGroup.DataSource = null;
                    DGV_FilterGroup.Visible = false;
                }
                if (skipControl != txtSubGroup)
                {
                    varUpDownKeySubGroup = 0;
                    DGV_FilterSubgroup.DataSource = null;
                    DGV_FilterSubgroup.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

    }
}
