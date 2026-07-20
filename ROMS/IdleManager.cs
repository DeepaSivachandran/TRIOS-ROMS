using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ROMS
{
    public class IdleManager : IMessageFilter
    {
        private Timer idleTimer;
        private DateTime lastActivityTime;
        private readonly int idleTimeoutMinutes;
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd); 
        private bool idlePopupPending = false;
        public IdleManager(int idleTimeoutMinutes)
        {
            this.idleTimeoutMinutes = idleTimeoutMinutes;
            lastActivityTime = DateTime.Now;

            idleTimer = new Timer();
            idleTimer.Interval = 1000; // check every second
            idleTimer.Tick += IdleTimer_Tick;
            idleTimer.Start();

            // Capture global input messages
            Application.AddMessageFilter(this);
        }

        public bool PreFilterMessage(ref Message m)
        {
            const int WM_MOUSEMOVE = 0x0200;
            const int WM_KEYDOWN = 0x0100;
            const int WM_LBUTTONDOWN = 0x0201;

            // Any of these messages mean user activity
            if (m.Msg == WM_MOUSEMOVE || m.Msg == WM_KEYDOWN || m.Msg == WM_LBUTTONDOWN)
            {
                lastActivityTime = DateTime.Now;
            }

            return false; // allow normal processing
        }
        private bool IsMyApplicationActive()
        {
            IntPtr foreground = GetForegroundWindow();

            if (foreground == IntPtr.Zero)
                return false;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.IsHandleCreated &&
                    frm.Visible &&
                    IsWindowVisible(frm.Handle) &&
                    frm.Handle == foreground)
                {
                    return true;
                }
            }

            return false;
        }
        private void IdleTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan idleTime = DateTime.Now - lastActivityTime;

            if (idleTime.TotalMinutes >= 1)
            {
                idlePopupPending = true;
            }

            // Wait until the user comes back to our application
            if (idlePopupPending && IsMyApplicationActive())
            {
                idlePopupPending = false;

                idleTimer.Stop();

                if (Application.OpenForms.OfType<DEF_IdleLogin>().Any())
                    return;

                Form owner =
                    Form.ActiveForm ??
                    Application.OpenForms.Cast<Form>().FirstOrDefault();

                using (DEF_IdleLogin login = new DEF_IdleLogin())
                {
                    login.StartPosition = FormStartPosition.CenterParent;

                    if (owner != null)
                        login.ShowDialog(owner);
                    else
                        login.ShowDialog();

                    if (login.IsPasswordCorrect)
                    {
                        lastActivityTime = DateTime.Now;
                        idleTimer.Start();
                    }
                }
            }
        }
    }
}
