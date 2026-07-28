using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class ProductDetails : Form
    {
        DataError objError;
        public int varProductCode = 0;
        private List<string> images = new List<string>();
        private int currentIndex = 0;

        private Image originalImage;
        private float zoom = 1.0f;

        public ProductDetails()
        {
            InitializeComponent();
        }
        private void ShowImage()
        {
            try
            {
                if (images.Count > 0)
                {
                    if (images.Count == 1) { btnPrev.Visible = false; btnNext.Visible = false; }
                    if (currentIndex == 0) { btnPrev.Visible = false; } else { btnPrev.Visible = true; }
                    if (currentIndex == images.Count - 1) { btnNext.Visible = false; } else { btnNext.Visible = true; }

                    pictureBox1.Image?.Dispose();
                    originalImage?.Dispose();

                    originalImage = Image.FromFile(images[currentIndex]);

                    udfnApplyZoom(1);
                    lblCount.Text = $"Image {currentIndex + 1} of {images.Count}";
                }
                else
                {
                    btnPrev.Visible = false;
                    btnNext.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (images.Count > 0)
                {
                    currentIndex = (currentIndex + 1) % images.Count;
                    ShowImage();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (images.Count > 0)
                {
                    currentIndex = (currentIndex - 1 + images.Count) % images.Count;
                    ShowImage();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            btnNext_Click(null, null); // Auto-slide to next image
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_Enter(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PM_ProductDetails_Load(object sender, EventArgs e)
        {
            try
            {
                udfnLoad();
                ShowImage();
                timer1.Interval = 2000; // 2 seconds per slide
                                        // timer1.Tick += Timer1_Tick;
                timer1.Start();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnLoad()
        {
            try
            {
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 1;
                objMR_Product.ParaProductCode = varProductCode;
                DataSet objDS = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDS = objdserv.udfnproductmasterlist(objMR_Product);
                objdserv.CloseConnection();
                if (objDS != null)
                {
                    //if (objDS.Tables[0].Rows.Count > 0)
                    //{
                    //    string varProductName = objDS.Tables[0].Rows[0]["ProductEName"].ToString().Replace("''", "'");
                    //    this.Text = varProductName;
                    //    lblTamilName.Text = Convert.ToString(objDS.Tables[0].Rows[0]["ProductTName"]);
                    //    lblTechnicalName.Text = Convert.ToString(objDS.Tables[0].Rows[0]["TechnicalName"]);
                    //    lblUnit.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Unit"]);
                    //    lblGroup.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Group"]);
                    //    lblSubgroup.Text = Convert.ToString(objDS.Tables[0].Rows[0]["SubGroup"]);
                    //    lblBrand.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Brand"]);
                    //}
                    //if (objDS.Tables[1].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                    //    {
                    //        grdSpecification.Rows.Add(objDS.Tables[1].Rows[i]["Attribute"].ToString(), objDS.Tables[1].Rows[i]["Value"].ToString(), objDS.Tables[1].Rows[i]["Measurement"].ToString());
                    //    }
                    //    grdSpecification.Columns["clmValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //}
                    if (objDS.Tables[2].Rows.Count > 0)
                    {
                        if (objDS.Tables[2].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[2].Rows.Count; i++)
                            {
                                string varImageName = Convert.ToString(objDS.Tables[2].Rows[i]["image_name"]);
                                images.Add(varImageName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {

            }
        }
        private void PM_ProductDetails_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            try
            {
                zoom += 0.1f;
                udfnApplyZoom(0);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            try
            {
                if (zoom > 0.2f)
                {
                    zoom -= 0.1f;
                    udfnApplyZoom(0);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnApplyZoom(int varFlag)
        {
            try
            {
                if (originalImage == null) return;

                int newWidth = 0;
                int newHeight = 0;
                if (varFlag == 1)
                {
                    newWidth =  (int)(340);
                    newHeight = (int)(370);
                }
                else
                {
                    newWidth = (int)(340 * zoom);
                    newHeight = (int)(370 * zoom);
                }

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

        private void BtnAnticlkRotation_Click(object sender, EventArgs e)
        {
            try
            {
                if (images.Count > 0)
                {
                    pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    pictureBox1.Refresh();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClkRotate_Click(object sender, EventArgs e)
        {
            try
            {
                if (images.Count > 0)
                {
                    pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    pictureBox1.Refresh();
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
