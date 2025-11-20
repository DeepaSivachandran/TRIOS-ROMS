using System;
using System.Collections.Generic;
using System.Linq;
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

        private void IdleTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan idleTime = DateTime.Now - lastActivityTime;

            if (idleTime.TotalMinutes >= idleTimeoutMinutes)
            {

                idleTimer.Stop();

                bool isAlreadyOpen = Application.OpenForms.OfType<DEF_IdleLogin>().Any();
                if (isAlreadyOpen)
                    return;

                // Get the correct owner window
                Form ownerForm = Form.ActiveForm
                                 ?? Application.OpenForms.Cast<Form>().FirstOrDefault()
                                 ?? null;

                DEF_IdleLogin obj = new DEF_IdleLogin();
                obj.StartPosition = FormStartPosition.CenterParent;

                if (ownerForm != null)
                    obj.ShowDialog(ownerForm);   //   Correct way
                else
                    obj.ShowDialog();            // Fallback

                if (obj.IsPasswordCorrect)
                {
                    lastActivityTime = DateTime.Now;
                    idleTimer.Start();
                }

                //obj.FormClosed += (s, args) =>
                //{
                //    if (obj.IsPasswordCorrect)
                //    {
                //        lastActivityTime = DateTime.Now; // reset idle time
                //        idleTimer.Start(); // resume idle check
                //    }
                //    else
                //    { 
                //        //Application.Exit();
                //    }
                //};
                //if (activeForm != null)
                //{
                //    obj.Owner = activeForm; // ensures it stays on top of the same form window
                //    obj.Show(activeForm);
                //}
                //else
                //{
                //    //obj.Show(); // fallback if no active form found
                //}
                //lastActivityTime = DateTime.Now; // reset after message
                //idleTimer.Start();
            }
        }
    }
}
