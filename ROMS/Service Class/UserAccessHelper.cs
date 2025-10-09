using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
namespace ROMS
{
    class UserAccessHelper
    {
        public static HashSet<string> _accessLevels;
       // public static string PrivilegeCode, SpecialPermissionCode;

        public static (string PrivilegeCode, List<(int MUP_Code, string EditAccess)> SpecialPermissions)  LoadUserAccess(int menuCode)
        { 
            string PrivilegeCode = string.Join(",",
            MainForm.objDtMenuDetailsUser?.AsEnumerable()
            .Where(r => r != null
            && r.Table.Columns.Contains("MU_Code")
            && r.Table.Columns.Contains("URM_Access_Level")
            && !r.IsNull("MU_Code")
            && r.Field<int?>("MU_Code") == menuCode
            && !r.IsNull("URM_Access_Level"))
            .Select(r => r.Field<string>("URM_Access_Level")) 
            ?? Enumerable.Empty<string>()
            );
 
            var SpecialPermissions = MainForm.objDtMenuSplPermissionUser?
            .AsEnumerable()
            .Where(r => r.Field<int?>("MUP_MU_Code") == menuCode
            && !r.IsNull("EditAccess")
            && !r.IsNull("MUP_Code"))
            .Select(r => (
            MUP_Code: r.Field<int>("MUP_Code"),
            EditAccess: r.Field<string>("EditAccess")
            ))
            .ToList() ?? new List<(int, string)>();
             
            return (PrivilegeCode, SpecialPermissions); 
        } 
        public static void SetToolStripAccess(ToolStripButton button,EventHandler clickHandler, bool hasAccess)
        {
            // Set visibility or enabled state
            button.Enabled = hasAccess; 
            if (hasAccess)  // Manage event attachment
            {
                // Attach only if not already attached
                button.Click -= clickHandler;
                button.Click += clickHandler;
            }
            else
            { 
                button.Click -= clickHandler; // Remove click handler to prevent action
                button.Visible = false;
            }
        }
    }
}
