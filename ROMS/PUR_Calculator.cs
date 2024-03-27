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
    public partial class PUR_Calculator : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError; 
        double varResult = 0;
        float varAns = 0, varNum = 0;
        int varCount = 0;
        public string PbValue = "";
        public string varResult1 = "0", varResult2 = "0", varResult3 = "0", varResult4 = "0";
        public PUR_Calculator()
        {
            InitializeComponent();
        }

        private void txtPassKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnAuthorise_Click(object sender, EventArgs e)
        {
            try { this.Close(); }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtValue.Text != "")
                {
                    lbltemptext.Text = txtValue.Text.Replace("%","/100");
                    varResult = Math.Round(Convert.ToDouble(new DataTable().Compute(lbltemptext.Text, null)), 3, MidpointRounding.AwayFromZero);
                }
                else { varResult = 0; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { lblFinalValue.Text = Convert.ToString(varResult); }
        }

        private void PUR_Calculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MainForm.objCP_Purchase.varCalculator = PbValue;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + 1;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + 2;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + 3;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + 4;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + 5;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + 6;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + 7;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + 8;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + 9;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnDot_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + '.';
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCompute()
        {
            try
            {
                switch (varCount)
                {
                    case 1:
                        varAns = varNum + float.Parse(txtValue.Text);
                        txtValue.Text = varAns.ToString();
                        break;
                    case 2:
                        varAns = varNum - float.Parse(txtValue.Text);
                        txtValue.Text = varAns.ToString();
                        break;
                    case 3:
                        varAns = varNum * float.Parse(txtValue.Text);
                        txtValue.Text = varAns.ToString();
                        break;
                    case 4:
                        varAns = varNum / float.Parse(txtValue.Text);
                        txtValue.Text = varAns.ToString();
                        break;
                    case 5:
                        varAns = varNum % float.Parse(txtValue.Text);
                        txtValue.Text = varAns.ToString();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSub_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + '-';
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPer_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCalculator("Per");
                txtValue.Text = txtValue.Text + '%';
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnDiv_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + '/';
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMul_Click(object sender, EventArgs e)
        {
            try
            {
                txtValue.Text = txtValue.Text + '*';
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnEql_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtValue.Text.Contains("%") == true)
                {
                    string[] Var = txtValue.Text.Split('+', '-', '*');
                    string[] Var1 = txtValue.Text.Split('%');
                    string value = "%";
                    string Var2 = Array.IndexOf(Var1, value).ToString();
                }
                txtValue.Text = lblFinalValue.Text;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnOK_Enter(object sender, EventArgs e)
        {
            try
            {
                btnOK.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtValue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                {
                    this.Close();
                    if (lblFinalValue.Text != "0")
                    {
                        MainForm.objCP_Purchase.varCalculator = lblFinalValue.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnOK_Leave(object sender, EventArgs e)
        {
            try
            {
                btnOK.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                if (lblFinalValue.Text != "0")
                {
                    MainForm.objCP_Purchase.varCalculator = lblFinalValue.Text;
                }
                else
                {
                    MainForm.objCP_Purchase.varCalculator = PbValue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCalculator("Add");
                txtValue.Text = txtValue.Text + '+';
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCalculator(string Func)
        {
            try
            {
                if(Func=="Add")
                {
                    varResult1 = txtValue.Text;
                    varCount = 1;
                }
                if(Func=="Per")
                {
                    if(varCount == 1)
                    {
                        int Res1 = 0;
                        string[] qw=txtValue.Text.Split('+');
                        int var =Convert.ToInt32(qw[1]);
                        Res1 = Convert.ToInt32(varResult1) + var;
                        varCount = varCount % var;
                        //varResult2 = Convert.ToInt32(varResult1) + var;
                    }
                    //varResult2 = varResult1+'%';
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
