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
    public partial class DEF_Start : Form
    {
        // Author : DEEPA
        // Created Date: 12-02-2020

        //*************** Object for Service Classes Initialisation  ***********
        DataValidation objValidation = new DataValidation();
        DataError objError;      
        public DEF_Start()
        {
            InitializeComponent();
            objValidation.resolutionsettingsForm(this);
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
        }
        //Added By Sathish For Screen Resolution Changed Time Font Size InCrease
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            try
            {
                string varPercentage = ""; decimal varPercentageWidth = 0, varPercentageHeight = 0, varIncreaseWidthSize = 0, varIncreaseHeightSize = 0;
                Panel myPanel = new Panel();
                myPanel.Size = new Size(this.Width, this.Height);
                varPercentage = objValidation.udfhScreenResolution(myPanel, this);
                string[] value = varPercentage.Split(',');
                varPercentageWidth = Convert.ToDecimal(value[0]);
                varPercentageHeight = Convert.ToDecimal(value[1]);

                varIncreaseWidthSize = this.Width + (this.Width * varPercentageWidth / 100);
                varIncreaseHeightSize = this.Height + (this.Height * varPercentageHeight / 100);
                this.Size = new Size(Convert.ToInt32(varIncreaseWidthSize), Convert.ToInt32(varIncreaseHeightSize));
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
