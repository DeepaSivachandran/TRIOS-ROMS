using ROMS.Model;
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
    public partial class CP_ProductImageApproval : Form
    {

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
        private Point dragStartPoint;
        private const int HANDLE_SIZE = 8;
        private Rectangle cropRect;
        private enum CropHandle
        {
            None, TopLeft, TopRight, BottomLeft, BottomRight,
            Left, Right, Top, Bottom
        }
        private CropHandle currentHandle = CropHandle.None;
        private List<string> imagePaths = new List<string>();


        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtProductHSN = new DataTable();
        DataTable dtPurHSN = new DataTable();
        DataTable dtSalesHSN = new DataTable();
        public int varproductcode = 0;
        public string varproductname = "";

        public CP_ProductImageApproval()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
            MainForm.objCP_ProductImageApprovalList.picLoader.Visible = false;
        }
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = null;

                        originalImage?.Dispose();
                        originalImage = null;

                        foreach (var ei in editableImages)
                        {
                            ei.Thumbnail.Image?.Dispose();
                            ei.Thumbnail.Image = null;
                        }

                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_ProductApproval_Load(object sender, EventArgs e)
        {

            try
            {
                dtProductHSN.Columns.Add("HSN_Type", typeof(int));
                dtProductHSN.Columns.Add("HSNID", typeof(int));
                dtProductHSN.Columns.Add("HSN_EffectiveFrom", typeof(string));
                dtProductHSN.Columns.Add("HSN_EffectiveTo", typeof(string));
                dtProductHSN.Columns.Add("PRHSN_ChangedDate", typeof(string));
                dtProductHSN.Columns.Add("PRHSN_MakerID", typeof(int));


                dtPurHSN.Columns.Add("HSN_Type", typeof(int));
                dtPurHSN.Columns.Add("HSNID", typeof(int));
                dtPurHSN.Columns.Add("HSN_EffectiveFrom", typeof(string));
                dtPurHSN.Columns.Add("HSN_EffectiveTo", typeof(string));
                dtPurHSN.Columns.Add("PRHSN_ChangedDate", typeof(string));
                dtPurHSN.Columns.Add("PRHSN_MakerID", typeof(int));


                dtSalesHSN.Columns.Add("HSN_Type", typeof(int));
                dtSalesHSN.Columns.Add("HSNID", typeof(int));
                dtSalesHSN.Columns.Add("HSN_EffectiveFrom", typeof(string));
                dtSalesHSN.Columns.Add("HSN_EffectiveTo", typeof(string));
                dtSalesHSN.Columns.Add("PRHSN_ChangedDate", typeof(string));
                dtSalesHSN.Columns.Add("PRHSN_MakerID", typeof(int));
                lblProductName.Text=varproductname;
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_ProductApproval_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    udfnUpdate();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (!cropMode) return;
                foreach (var handle in GetHandleRects(cropRect))
                {
                    if (handle.Value.Contains(e.Location))
                    {
                        currentHandle = handle.Key;
                        dragStartPoint = e.Location;
                        return;
                    }
                }
                if (cropRect.Contains(e.Location))
                {
                    currentHandle = CropHandle.None;
                }
                //if (e.Button == MouseButtons.Left)
                //{
                //    isDragging = true;
                //    dragStartPoint = e.Location;
                //    pictureBox1.Cursor = Cursors.SizeAll;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {

                if (!cropMode || currentHandle == CropHandle.None || e.Button != MouseButtons.Left) return;

                int dx = e.X - dragStartPoint.X;
                int dy = e.Y - dragStartPoint.Y;

                switch (currentHandle)
                {
                    case CropHandle.TopLeft:
                        cropRect.X += dx;
                        cropRect.Y += dy;
                        cropRect.Width -= dx;
                        cropRect.Height -= dy;
                        break;

                    case CropHandle.TopRight:
                        cropRect.Y += dy;
                        cropRect.Width += dx;
                        cropRect.Height -= dy;
                        break;

                    case CropHandle.BottomLeft:
                        cropRect.X += dx;
                        cropRect.Width -= dx;
                        cropRect.Height += dy;
                        break;

                    case CropHandle.BottomRight:
                        cropRect.Width += dx;
                        cropRect.Height += dy;
                        break;

                    // Optional edge handles
                    case CropHandle.Left:
                        cropRect.X += dx;
                        cropRect.Width -= dx;
                        break;

                    case CropHandle.Right:
                        cropRect.Width += dx;
                        break;

                    case CropHandle.Top:
                        cropRect.Y += dy;
                        cropRect.Height -= dy;
                        break;

                    case CropHandle.Bottom:
                        cropRect.Height += dy;
                        break;
                }

                dragStartPoint = e.Location;
                pictureBox1.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            currentHandle = CropHandle.None;
            //isDragging = false;
            //pictureBox1.Cursor = Cursors.Default;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                UpdateZoomButtonsVisibility();
                if (!cropMode) return;

                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, cropRect);
                }
                foreach (var handle in GetHandleRects(cropRect))
                {
                    e.Graphics.FillEllipse(Brushes.White, handle.Value);
                    e.Graphics.DrawEllipse(Pens.Black, handle.Value);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void UpdateZoomButtonsVisibility()
        {
            bool hasImage = pictureBox1.Image != null;
            //btnPlus.Visible = hasImage;
            //btnMinus.Visible = hasImage;
            //btnClkRotate.Visible = hasImage;
            //btnAnticlkRotation.Visible = hasImage;
            //btnCrop.Visible = hasImage;
            //btnResetImage.Visible = hasImage;
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
                btnRemove.BringToFront();
                btnRemove.Location = new Point(100, 0);
                flowLayoutPanel1.Controls.Add(panel);

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
        private Dictionary<CropHandle, Rectangle> GetHandleRects(Rectangle rect)
        {
            int hs = HANDLE_SIZE;
            Dictionary<CropHandle, Rectangle> handles = new Dictionary<CropHandle, Rectangle>
            {
                { CropHandle.TopLeft, new Rectangle(rect.Left - hs/2, rect.Top - hs/2, hs, hs) },
                { CropHandle.TopRight, new Rectangle(rect.Right - hs/2, rect.Top - hs/2, hs, hs) },
                { CropHandle.BottomLeft, new Rectangle(rect.Left - hs/2, rect.Bottom - hs/2, hs, hs) },
                { CropHandle.BottomRight, new Rectangle(rect.Right - hs/2, rect.Bottom - hs/2, hs, hs) },
                { CropHandle.Left, new Rectangle(rect.Left - hs/2, rect.Top + rect.Height/2 - hs/2, hs, hs) },
                { CropHandle.Right, new Rectangle(rect.Right - hs/2, rect.Top + rect.Height/2 - hs/2, hs, hs) },
                { CropHandle.Top, new Rectangle(rect.Left + rect.Width/2 - hs/2, rect.Top - hs/2, hs, hs) },
                { CropHandle.Bottom, new Rectangle(rect.Left + rect.Width/2 - hs/2, rect.Bottom - hs/2, hs, hs) },
            };
            return handles;
        }
        private void btnImageUpdate_Click(object sender, EventArgs e)
        {
            udfnUpdate();
        }
        public void udfnUpdate()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                List<string> imageNameList = new List<string>();

                DataService objdser = new DataService();
                string destinationPath = objdser.displaydata("SELECT TOP 1 image_path FROM DEF_SharedFolderPath ORDER BY SFID DESC");
                objdser.CloseConnection();

                string destinationFolder = Path.GetDirectoryName(destinationPath);
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                int varFileCount = 1;
                string varImagePath = "";

                string[] existingFiles = Directory.GetFiles(destinationPath, varproductcode + "_*");

                HashSet<string> updatedImages = new HashSet<string>(
                    editableImages.Select(ei =>
                        ei.EditedImage != null
                            ? $"{varproductcode}_{editableImages.IndexOf(ei) + 1}{Path.GetExtension(ei.FilePath)}"
                            : Path.GetFileName(ei.FilePath)
                    )
                );

                foreach (string file in existingFiles)
                {
                    string fileName = Path.GetFileName(file);
                    if (!updatedImages.Contains(fileName))
                    {
                        if (File.Exists(file))
                        {
                            File.SetAttributes(file, FileAttributes.Normal);
                            pictureBox1.Image?.Dispose();
                            pictureBox1.Image = null;

                            originalImage?.Dispose();
                            originalImage = null;
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            File.Delete(file);
                        }
                    }
                }

                foreach (var ei in editableImages)
                {
                    string extensionName = Path.GetExtension(ei.FilePath);
                    string imageName = $"{varproductcode}_{varFileCount}{extensionName}";
                    string destinationFile = Path.Combine(destinationPath, imageName);

                    if (ei.EditedImage != null)
                    {
                        if (File.Exists(destinationFile))
                        {
                            File.SetAttributes(destinationFile, FileAttributes.Normal);
                            pictureBox1.Image?.Dispose();
                            pictureBox1.Image = null;

                            originalImage?.Dispose();
                            originalImage = null;
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            File.Delete(destinationFile);
                        }
                        using (MemoryStream ms = new MemoryStream())
                        {
                            ei.EditedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            File.WriteAllBytes(destinationFile, ms.ToArray());
                        }
                    }
                    else
                    {
                        if (ei.FilePath != destinationFile)
                        {
                            if (File.Exists(destinationFile))
                            {
                                File.SetAttributes(destinationFile, FileAttributes.Normal);
                                pictureBox1.Image?.Dispose();
                                pictureBox1.Image = null;

                                originalImage?.Dispose();
                                originalImage = null;
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                File.Delete(destinationFile);
                            }

                            using (FileStream sourceStream = new FileStream(ei.FilePath, FileMode.Open, FileAccess.Read))
                            using (FileStream destStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
                            {
                                sourceStream.CopyTo(destStream);
                            }
                        }
                    }


                    imageNameList.Add(imageName);
                    varFileCount++;

                    if (string.IsNullOrEmpty(varImagePath))
                        varImagePath = imageName;
                    else
                        varImagePath += "," + imageName;
                }
                string result = "";
                result = objspdservice.udfnProductMaster(20, varproductcode, "", "", "", 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "", 0, null, 0, "", 0, 0, 0, 0, 0, null, "", "", "", 0, "", varImagePath, 0, 0, 0, null, 0, 0, 0, 0, null, 0, "", "", "", "", "", 0, 0);

                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3" && varvalue[1] == "1")
                {
                Verify:
                    MainForm.objCP_Verify = new CP_Verify();
                    MainForm.objCP_Verify.ShowDialog();

                    if (MainForm.objCP_Verify.flag == 1)
                    {
                        string ApproverID = MainForm.objCP_Verify.varUserId;

                        result = objspdservice.udfnProductMaster(20, varproductcode, "", "", "", 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, "", ApproverID, MainForm.pbIpAddress, "", 0, null, 1, "", 0, 0, 0, 0, 0, null, "", "", "", 0, "", varImagePath, 0, 0, 0, null, 0, 0, 0, 0, null, 0, "", "", "", "", "", 0, 0);

                        string[] value = result.Split('~');

                        if (value[0] == "3")
                        {
                            MessageBox.Show(value[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            MainForm.objCP_ProductImageApprovalList.udfnList();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(value[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            if (value[0] == "5")
                                goto Verify;
                        }

                    }

                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnImgClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnEdit()
        {
            try
            {
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                if (varproductcode != 0)
                {
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 1;
                    objMR_Product.ParaProductCode = varproductcode;
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    DataService objdservice = new DataService();
                    objDS = objdserv.udfnproductmasterlist(objMR_Product);
                    objdserv.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[2].Rows.Count > 0)
                        {
                            udfnBindImages(objDS.Tables[2]);
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
        public void udfnBindImages(DataTable objdt)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear(); // Remove all controls
                imagePaths.Clear(); // Clear the stored paths
                pictureBox1.Image = null;
                if (objdt.Rows.Count > 0)
                {
                    for (int i = 0; i < objdt.Rows.Count; i++)
                    {
                        string varImageName = Convert.ToString(objdt.Rows[i]["image_name"]);
                        imagePaths.Add(varImageName);
                        AddImageToPanel(varImageName);
                        if (imagePaths.Count == 1)
                        {
                            ZoomImage(varImageName);
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
    }
}





