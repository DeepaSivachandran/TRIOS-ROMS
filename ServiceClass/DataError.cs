using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCOLabeling
{
    public class DataError
    {
        StreamWriter objStream;
        string strFileName;
        FileStream fs;
        public void WriteFile(Exception e)
        {
            string strHTML = null;
            strHTML = "<br><table name='errTab' border=1 bordercolor=Blue style='color:Purple;' cellpadding=0 cellspacing=0>";
            strHTML = strHTML + "<tr>";
            strHTML = strHTML + "<td style='font-weight:bold;'>Date And Time</td>";
            strHTML = strHTML + "<td>" + System.DateTime.Today.ToLongDateString() + ", " + System.DateTime.Now.ToLongTimeString() + "</td>";
            strHTML = strHTML + "</tr>";
            strHTML = strHTML + "<tr>";
            strHTML = strHTML + "<td style='font-weight:bold;'> Message </td>";
            strHTML = strHTML + "<td>" + e.Message + "</td>";
            strHTML = strHTML + "</tr>";
            strHTML = strHTML + "<tr>";
            strHTML = strHTML + "<td style='font-weight:bold;'> Source </td>";
            strHTML = strHTML + "<td>" + e.Source + "</td>";
            strHTML = strHTML + "</tr>";
            strHTML = strHTML + "<tr>";
            strHTML = strHTML + "<td style='font-weight:bold;'> Stack Trace </td>";
            strHTML = strHTML + "<td>" + e.StackTrace + "</td>";
            strHTML = strHTML + "</tr>";
            strHTML = strHTML + "</table>";
            if (object.ReferenceEquals(strHTML, DBNull.Value))
            {
            }
            else
            {
                if (File.Exists(Application.StartupPath + "\\LogFiles\\" + DateTime.Today.ToString("MM-dd-yy") + ".html"))
                {
                    using (fs = new FileStream(Application.StartupPath + "\\LogFiles\\" + DateTime.Today.ToString("MM-dd-yy") + ".html", FileMode.Append, FileAccess.Write))
                    {
                        using (objStream = new StreamWriter(fs, Encoding.UTF8))
                        {
                            objStream.WriteLine(strHTML);
                        }
                    }
                }
                else
                {
                    using (fs = new FileStream(Application.StartupPath + "\\LogFiles\\" + DateTime.Today.ToString("MM-dd-yy") + ".html", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        using (objStream = new StreamWriter(fs, Encoding.UTF8))
                        {
                            objStream.WriteLine(strHTML);
                        }
                    }
                }
                objStream.Close();
                objStream = null;
            }

        }
    }
}
