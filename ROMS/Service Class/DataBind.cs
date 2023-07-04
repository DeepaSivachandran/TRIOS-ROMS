using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    class DataBind
    {
        public DataService objService;
        DataError objError;
        public void BindComboBoxListSelected(string strTableName, string strCondition, string strCondition2, ComboBox ctlComboBox, string strNeedALL, string strItem, string strValue)
        {
            try
            {
                objService = new DataService();
                objService.FillDataSetSelectedField(strTableName, strCondition, strCondition2);
                ctlComboBox.ValueMember = objService.ObjDT.Columns[strValue].Caption;
                ctlComboBox.DisplayMember = objService.ObjDT.Columns[strItem].Caption;
                if (!string.IsNullOrEmpty(strNeedALL))
                    ctlComboBox.Items.Insert(0, strNeedALL);
                ctlComboBox.DataSource = objService.ObjDT;
                objService.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
