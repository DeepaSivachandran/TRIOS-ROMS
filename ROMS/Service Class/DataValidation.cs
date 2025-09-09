
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ROMS
{
    class DataValidation
    {
        DataError objError;
        public bool blnFlag;
        public SecurityController _security;
        public DataValidation()
        {
            //' this is constructor
        }
        public string Encrypt(string text)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(text);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    text = Convert.ToBase64String(ms.ToArray());
                }
            }
            return text;
        }
        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        public void screensettings(Form SSSExamCell)
        {
            int i = Screen.FromControl(SSSExamCell).Bounds.Width;
            int k = i / 2;
            int fw = SSSExamCell.Width;
            int s = fw / 2;
            SSSExamCell.Location = new System.Drawing.Point((k - s) - 5, 30);
        }
        public void screensettingsChild(Form SSSExamCell)
        {
            int i = Screen.FromControl(SSSExamCell).Bounds.Width;
            int k = i / 2;
            int fw = SSSExamCell.Width;
            int s = fw / 2;
            SSSExamCell.Location = new System.Drawing.Point(k - s, 80);
        }
        public void resolutionsettings(Panel mainpanel, Form SSSExamCell)
        {
            try
            {
                int pointx, pointy, screenwidth, screenheight, panelwidth, panelheight;
                panelwidth = mainpanel.Width;
                panelheight = mainpanel.Height;
                screenheight = Screen.PrimaryScreen.WorkingArea.Height;
                screenwidth = Screen.PrimaryScreen.WorkingArea.Width;
                if (screenwidth > 1366)
                {
                    pointx = ((screenwidth / 2) - (panelwidth / 2));
                    pointy = ((screenheight / 2) - (panelheight / 2));
                    mainpanel.Location = new Point(pointx, (pointy - 50));
                    SSSExamCell.Size = new Size(screenwidth - 5, screenheight - 127);
                }
                else
                {
                    mainpanel.BackColor = System.Drawing.Color.White;
                    SSSExamCell.BackColor = System.Drawing.SystemColors.ActiveBorder;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void screensettingspanel(Panel SSSExamCell)
        {
            int i = Screen.FromControl(SSSExamCell).Bounds.Width;
            int j = Screen.FromControl(SSSExamCell).Bounds.Height;
            int m = j / 2;
            int k = i / 2;
            int fw = SSSExamCell.Width;
            int fh = SSSExamCell.Height;
            int s = fw / 4;
            int n = fh / 4;
            SSSExamCell.Location = new System.Drawing.Point((k - s) - 180, (m - n) + 25);
        }
        public bool internetconnection()
        {
            Ping myPing = new Ping();
            String host = "4.2.2.2";
            byte[] buffer = new byte[32];
            int timeout = 1000;
            PingOptions pingOptions = new PingOptions();
            PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
            PingReply reply1 = myPing.Send("8.8.8.8", timeout, buffer, pingOptions);
            if (reply.Status == IPStatus.Success || reply1.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void fullresolutionsettingsForm(Form SSSExamCell)
        {
            try
            {
                int screenwidth, screenheight, panelwidth, panelheight, pointx, pointy;
                panelwidth = SSSExamCell.Width;
                panelheight = SSSExamCell.Height;
                screenheight = Screen.PrimaryScreen.WorkingArea.Height;
                screenwidth = Screen.PrimaryScreen.WorkingArea.Width;
                if (screenwidth > 1366)
                {
                    pointx = ((screenwidth / 2) - (panelwidth / 2));
                    pointy = ((screenheight / 2) - (panelheight / 2));
                    SSSExamCell.Location = new Point(pointx, (pointy - 35));
                }
                else
                {
                    SSSExamCell.BackColor = System.Drawing.SystemColors.ActiveBorder;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void resolutionsettingsForm(Form SSSExamCell)
        {
            try
            {
                int screenwidth, screenheight, panelwidth, panelheight, pointx, pointy;
                panelwidth = SSSExamCell.Width;
                panelheight = SSSExamCell.Height;
                screenheight = Screen.PrimaryScreen.WorkingArea.Height;
                screenwidth = Screen.PrimaryScreen.WorkingArea.Width;
                if (screenwidth > 1366)
                {
                    pointx = ((screenwidth / 2) - (panelwidth / 2));
                    pointy = ((screenheight / 2) - (panelheight / 2));
                    SSSExamCell.Location = new Point(pointx, (pointy - 35));
                    if (SSSExamCell.BackColor == SystemColors.AppWorkspace)
                    {
                        SSSExamCell.BackColor = System.Drawing.SystemColors.AppWorkspace;
                    }
                    else
                    {
                        SSSExamCell.BackColor = System.Drawing.SystemColors.Window;
                    }

                }
                else
                {
                    if (SSSExamCell.BackColor == SystemColors.AppWorkspace)
                    {
                        SSSExamCell.BackColor = System.Drawing.SystemColors.AppWorkspace;
                    }
                    else
                    {
                        SSSExamCell.BackColor = System.Drawing.SystemColors.Window;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void ListResolutionFormCompany(Form SSSExamCell)
        {
            try
            {
                int screenwidth, screenheight, panelwidth, panelheight, pointx, pointy;
                panelwidth = SSSExamCell.Width;
                panelheight = SSSExamCell.Height;
                screenheight = Screen.PrimaryScreen.WorkingArea.Height;
                screenwidth = Screen.PrimaryScreen.WorkingArea.Width;
                if (screenwidth > 1366)
                {
                    pointx = ((screenwidth / 2) - (panelwidth / 2));
                    pointy = ((screenheight / 2) - (panelheight / 2));
                    SSSExamCell.Location = new Point(pointx + 100, (pointy));

                }
                else
                {
                    pointx = ((screenwidth / 2) - (panelwidth / 2));
                    pointy = ((screenheight / 2) - (panelheight / 2));
                    SSSExamCell.Location = new Point(pointx + 100, (pointy - 20));
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                throw ex;
            }
        }
        public bool FormatAlphbetic(string inputText)
        {

            try
            {
                if (Regex.IsMatch(inputText, "^[A-Za-z .]*$") == true)
                {
                    blnFlag = true;
                }
                else
                {
                    blnFlag = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return blnFlag;
        }
        public bool FormatSpecialCharacter(string inputText)
        {

            try
            {
                if (Regex.IsMatch(inputText, "[^0-9A-Za-z@()/ \b_-]+$") == true)
                {
                    blnFlag = true;
                }
                else
                {
                    blnFlag = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return blnFlag;
        }
        public bool FormatAlphbeticOnly(string inputText)
        {
            try
            {
                if (Regex.IsMatch(inputText, "^[A-Za-z ]*$") == true)
                {
                    blnFlag = true;
                }
                else
                {
                    blnFlag = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return blnFlag;
        }
        public string getcurrencyvalue(string varValue)
        {
            string varreturnvalue = "";
            try
            {
                decimal parsed = decimal.Parse(varValue, CultureInfo.InvariantCulture);
                CultureInfo hindi = new CultureInfo("hi-IN");
                string text = string.Format(hindi, "{0:c}", parsed);
                varreturnvalue = text.Substring(2, text.Length - 2);
                if (varreturnvalue.StartsWith(","))
                {
                    varreturnvalue = text.Substring(1, text.Length - 1);
                }
                if (double.Parse(varValue) != double.Parse(varreturnvalue))
                {
                    varreturnvalue = text.Substring(1, text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return varreturnvalue;
        }

        public string identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            System.Management.ManagementClass mc =
        new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
        public string baseId()
        {
            return identifier("Win32_BaseBoard", "Model") + ","
            + identifier("Win32_BaseBoard", "Manufacturer") + ","
            + identifier("Win32_BaseBoard", "Name") + ","
            + identifier("Win32_BaseBoard", "SerialNumber");
        }
        public bool FormatEMail(string inputText)
        {
            try
            {
                if (Regex.IsMatch(inputText, "^([\\w-_]+\\.)*[\\w-_]+\\@([\\w-_]+\\.)+[a-zA-Z]{2,3}$") == true)
                {
                    blnFlag = true;
                }
                else
                {
                    blnFlag = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return blnFlag;
        }
        public bool FormatNumeric(string inputText)
        {
            try
            {
                double output = 0;
                if (double.TryParse(inputText, NumberStyles.Number, CultureInfo.InvariantCulture, out output) == true)
                {
                    blnFlag = true;
                }
                else
                {
                    blnFlag = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return blnFlag;
        }
        public void ListResolutionForm(Form SSSExamCell)
        {
            try
            {
                int screenwidth, screenheight, panelwidth, panelheight, pointx, pointy;
                panelwidth = SSSExamCell.Width;
                panelheight = SSSExamCell.Height;
                screenheight = Screen.PrimaryScreen.WorkingArea.Height;
                screenwidth = Screen.PrimaryScreen.WorkingArea.Width;
                if (screenwidth > 1366)
                {
                    pointx = ((screenwidth / 2) - (panelwidth / 2));
                    pointy = ((screenheight / 2) - (panelheight / 2));
                    SSSExamCell.Location = new Point(pointx + 100, (pointy - 35));
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                throw ex;
            }
        }
        public void setFontAndFontSize(Form SSSExamCell)
        {
            try
            {
                GetAllControls(SSSExamCell, new List<Control>());
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {
                if (c is TextBox) { list.Add(c); c.Font = new System.Drawing.Font("Segoe UI", 9.5F); }
                if (c is Label) { list.Add(c); c.Font = new System.Drawing.Font("Segoe UI", 9.5F); }
                if (c is RadioButton) { list.Add(c); c.Font = new System.Drawing.Font("Segoe UI", 9.5F); }
                if (c is DataGrid) { list.Add(c); c.Font = new System.Drawing.Font("Segoe UI", 9.5F); }
                if (c is Button) { list.Add(c); c.Font = new System.Drawing.Font("Segoe UI", 9.5F); }
                if (c is CheckBox) { list.Add(c); c.Font = new System.Drawing.Font("Segoe UI", 9.5F); }
                if (c is GroupBox) { list.Add(c); c.Font = new System.Drawing.Font("Segoe UI", 9.5F); }
                if (c is LinkLabel) { list.Add(c); c.Font = new System.Drawing.Font("Segoe UI", 9.5F); }
                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
            }
            return list;
        }
        public void setFontSize_TotalLabel(Label lblTotal)
        {
            try
            {
                lblTotal.Font = new System.Drawing.Font("Segoe UI", 20F);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void setFontSize_TotalTextBox(TextBox txtTotal)
        {
            try
            {
                txtTotal.Font = new System.Drawing.Font("Segoe UI", 20F);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public bool CheckSpecialCharacter(KeyPressEventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[^0-9A-Za-z@().,#/' \b_-]+$"))
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); return false; }
        }
        public bool FormatAlphbeticAndNumeric(KeyPressEventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[^0-9 \b]+$"))
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); return false; }
        }
        public bool CheckNumericWithDot(KeyPressEventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[^0-9 .\b]+$"))
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); return false; }
        }

        public bool FormatAlphbeticNumericAndSpecialchar(string inputText)
        {
            try
            {
                if (Regex.IsMatch(inputText, "^[A-Za-z0-9 ,.\"+*-/_()&@']*$") == true)
                {
                    blnFlag = true;
                }
                else
                {
                    blnFlag = false;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return blnFlag;
        }
        public bool CheckWithSpecialCharacter(KeyPressEventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[^0-9A-Za-z@()'. /\b_-]+$"))
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); return false; }
        }
        public bool FormatSpecialCharacterKey(KeyPressEventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[^0-9A-Za-z@() /\b_-]+$"))
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); return false; }
        }
        public bool FormatAlphbeticAndNumeric(string inputText)
        {
            try
            {
                if (Regex.IsMatch(inputText, "^[A-Za-z0-9 ,.\"+*-/_()]*$") == true)
                {
                    blnFlag = true;
                }
                else
                {
                    blnFlag = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return blnFlag;
        }
        public bool FormatNumericOnly(string inputText)
        {
            try
            {
                if (Regex.IsMatch(inputText, "^[0-9]*$") == true)
                {
                    blnFlag = true;
                }
                else
                {
                    blnFlag = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return blnFlag;
        }
        public bool FormatAlphabeticWithSpaceOnly(KeyPressEventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "^[a-zA-Z\\s\b]+$"))
                {
                    blnFlag = false;
                }
                else
                {
                    blnFlag = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return blnFlag;
        }
        public bool checkCloudAccess()
        {
            try
            {
                bool varStatus = false;
                string varCloudUrl = ConfigurationManager.AppSettings["cloudurl"];
                string varCloudActivationUrl = ConfigurationManager.AppSettings["cloudactivationurl"];
                varStatus = checkUrl(varCloudActivationUrl);
                if (varStatus == true)
                {
                    varStatus = checkUrl(varCloudActivationUrl);
                }
                return varStatus;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool checkUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 15000;
            request.Method = "HEAD"; // As per Lasse's comment
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException)
            {
                return false;
            }
        }
        //public void CrySqlConnection(ReportDocument objBillReport)
        //{
        //    try
        //    {
        //        SPCall tmpspcall = new SPCall();
        //        SqlConnection objConn = new SqlConnection();
        //        //  SqlConnection objConn = new SqlConnection(ConfigurationManager.AppSettings["ConnStr"]);
        //        string connectstring = tmpspcall.connectionstring();
        //        objConn = new System.Data.SqlClient.SqlConnection(connectstring);

        //        TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
        //        TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
        //        ConnectionInfo crConnectionInfo = new ConnectionInfo();
        //        Tables CrTables = default(Tables);
        //        crConnectionInfo.ServerName = objConn.DataSource;
        //        crConnectionInfo.DatabaseName = objConn.Database;
        //        string path = Application.StartupPath + "\\Server Settings\\serversettings.txt";
        //        _security = new SecurityController();
        //        if (File.Exists(path))
        //        {
        //            string lines = File.ReadAllText(path);
        //            if (lines != null & lines != "")
        //            {
        //                string[] words = lines.Split(',');
        //                crConnectionInfo.UserID = words[2];
        //                // string pwd = Decrypt(words[3], "sblw-3hn8-sqoy19");
        //                string pwd = _security.Decrypt(words[2], words[3]);
        //                crConnectionInfo.Password = pwd;
        //            }
        //        }
        //        // crConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings["SqlPassword"];
        //        CrTables = objBillReport.Database.Tables;
        //        foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
        //        {
        //            crtableLogoninfo = CrTable.LogOnInfo;
        //            crtableLogoninfo.ConnectionInfo = crConnectionInfo;
        //            CrTable.ApplyLogOnInfo(crtableLogoninfo);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}

        public DateTime udfndateconvertion(string paraDate)
        {
            DateTime varReturnDate = default(DateTime);
            string format;
            format = "dd/MM/yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;
            try
            {
                varReturnDate = DateTime.ParseExact(paraDate, format, provider);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return varReturnDate;
        }

        public string DefPrinterName(string PrinterName)
        {
            string temp = PrinterName;
            PrinterName = "";
            string paths = Application.StartupPath + "\\Printer Settings\\printersettings.txt";
            if (File.Exists(paths))
            {
                string line;
                StreamReader file = new StreamReader(paths);
                while ((line = file.ReadLine()) != null)
                {
                    if (line != null & line != "")
                    {
                        string[] words = line.Split(',');
                        if (words[0] == temp)
                        {
                            PrinterName = words[1];
                        }
                    }
                }
                file.Close();
            }
            return PrinterName;
        }
        //Created by Venkat
        //created on 08/08/2023; reason validate gstin

        public bool IsValidGSTIN(string gstin)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(gstin))
                    return false;
                return gstin.Length == 15 && Regex.IsMatch(gstin, @"^[a-zA-Z0-9]+$");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                return false;
            }
        }


        //Created by Venkat
        //created on 08/08/2023; reason validate PAN
        public bool IsValidPAN(string pan)
        {
            try
            {
                // Check if PAN is null or empty
                if (string.IsNullOrWhiteSpace(pan))
                    return false;

                // Check if PAN matches the format: 5 alphabets, 4 numbers, 1 alphabet
                return Regex.IsMatch(pan, @"^[A-Z]{5}\d{4}[A-Z]$");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                return false;
            }
        }

        //Created by Venkat
        //created on 08/08/2023; reason validate esiNumber
        public bool IsValidESINumber(string esiNumber)
        {

            try
            {  // Check if ESI Number is null or empty
                if (string.IsNullOrWhiteSpace(esiNumber))
                    return false;

                // Check if length is 17 characters
                return esiNumber.Length == 17;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                return false;
            }
        }

        //Created by Venkat
        //created on 08/08/2023; reason validate fssai

        public bool IsValidFSSAI(string fssai)
        {
            try
            {
                // Check if FSSAI is null or empty
                if (string.IsNullOrWhiteSpace(fssai))
                    return false;

                // Check if FSSAI matches the format: 14 digits
                return Regex.IsMatch(fssai, @"^\d{14}$");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                return false;
            }
        }
        //Created by Venkat
        //created on 08/08/2023; reason validate fssai

        public bool IsValidEPF(string epf)
        {
            try
            {
                // Check if EPF is null or empty
                if (string.IsNullOrWhiteSpace(epf))
                    return false;

                // Check if EPF matches the format
                return Regex.IsMatch(epf, @"^[A-Z]{2}/[A-Z]{3}/\d{1,7}/\d{0,3}/\d{1,7}$");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                return false;
            }
        }
        //Created by Venkat
        //created on 08/08/2023; reason validate fssai

        public bool IsValidUrl(string url)
        {
            try
            {
                Uri uriResult;
                bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                return result;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                return false;
            }
        }

        //Created by Venkat
        //created on 15/08/2023; reason crystal report connection
        //Modified By Sathish ON 09-09-2025 For Subreport Open time ask password
        public void CrySqlConnection(ReportDocument objBillReport)
        {
            try
            {
                SPCall tmpspcall = new SPCall();
                SqlConnection objConn = new SqlConnection();
                string connectstring = tmpspcall.connectionstring();
                objConn = new System.Data.SqlClient.SqlConnection(connectstring);

                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables = default(Tables);
                crConnectionInfo.ServerName = objConn.DataSource;
                crConnectionInfo.DatabaseName = objConn.Database;
                string path = Application.StartupPath + "\\Server Settings\\serversettings.txt";
                _security = new SecurityController();
                if (File.Exists(path))
                {
                    string lines = File.ReadAllText(path);
                    if (lines != null & lines != "")
                    {
                        string[] words = lines.Split(',');
                        crConnectionInfo.UserID = words[2];
                        // string pwd = Decrypt(words[3], "sblw-3hn8-sqoy19");
                        string pwd = _security.Decrypt(words[2], words[3]);
                        crConnectionInfo.Password = pwd;
                    }
                }
                // crConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings["SqlPassword"];

                // Apply to tables in main report
                CrTables = objBillReport.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                    CrTable.Location = CrTable.Location.Substring(CrTable.Location.LastIndexOf(".") + 1);
                }
                // Apply to all tables in subreports
                //foreach (ReportDocument subreport in objBillReport.Subreports)
                //{
                //    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in subreport.Database.Tables)
                //    {
                //        crtableLogoninfo = CrTable.LogOnInfo;
                //        crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                //        CrTable.ApplyLogOnInfo(crtableLogoninfo);
                //        CrTable.Location = CrTable.Location.Substring(CrTable.Location.LastIndexOf(".") + 1);
                //    }
                //}

                //SqlConnection objConn = new SqlConnection(ConfigurationManager.AppSettings["ConnStr"]);

                //TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                //TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                //ConnectionInfo crConnectionInfo = new ConnectionInfo();
                //Tables CrTables = default(Tables);
                //crConnectionInfo.ServerName = objConn.DataSource;
                //crConnectionInfo.DatabaseName = objConn.Database;
                //crConnectionInfo.UserID = ConfigurationManager.AppSettings["Sqluser"]; ;
                //crConnectionInfo.Password = ConfigurationManager.AppSettings["SqlPassword"];
                //CrTables = objBillReport.Database.Tables;
                //foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                //{
                //    crtableLogoninfo = CrTable.LogOnInfo;
                //    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                //    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public string udfnDecimal(string qty, int decimalvalue)
        {
            string decimalqty = "0"; try
            {
                decimal value = Convert.ToDecimal(qty);
                decimalqty = Convert.ToString(value.ToString("0." + new string('0', decimalvalue)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return decimalqty;
        }
        public bool udfnGSTIN(KeyPressEventArgs e)
        {
            try
            {
                if ((char.IsLetter(e.KeyChar)) || (char.IsNumber(e.KeyChar))  || e.KeyChar == (char)8)
                {
                    e.Handled = false;
                    return false;
                }
                else
                {
                    e.Handled = true;
                    return true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                return false;
            }
        }
    }
}
