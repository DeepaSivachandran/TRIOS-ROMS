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
        public void BindCheckedListBox(string strTableName, string strCondition, string strFields,
                               CheckedListBox ctlCheckedListBox, string strItem, string strValue)
        {
            try
            {
                objService = new DataService();
                objService.FillDataSetSelectedField(strTableName, strCondition, strFields);

                ctlCheckedListBox.DataSource = objService.ObjDT;
                ctlCheckedListBox.DisplayMember = objService.ObjDT.Columns[strItem].Caption;
                ctlCheckedListBox.ValueMember = objService.ObjDT.Columns[strValue].Caption;

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
