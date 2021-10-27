using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.Windows;
namespace Webhook_Sender
{
    class API
    {
        public static void OnStart(string version, string needed_v, string killswitch)
        {
            if(version == needed_v)
            {

            }
            else
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("A new Update is available, do you want to Update?", "Update Checker", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start("");
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            if (killswitch != "no")
            {
                System.Windows.Forms.MessageBox.Show("This Programm has been Killed by the Developer. (Killswitch is on)");
                Process.GetCurrentProcess().Kill();
            }
        }
        public static void SecurityCheck()
        {
            var ws = "https://kingbob-software.de/code_g_t_hub__WebHook_Sender/";
            var file = "kswitch.html";
            string data;
            using (WebClient sws = new WebClient())
            {
                data = sws.DownloadString(ws+file);
            }
            if (data != "no")
            {
                System.Windows.Forms.MessageBox.Show("This Programm has been Killed by the Developer. (Killswitch is on)");
                Process.GetCurrentProcess().Kill();
            }
        }
        public static void WebSession(string version)
        {
            var website = "https://kingbob-software.de/code_g_t_hub__WebHook_Sender/";
            var file_update = "upt.html";
            var file_killswitch = "kswitch.html"; 
            using (WebClient site = new WebClient())
            {
                string data_update_version = site.DownloadString(website+file_update);
                string data_killswitch = site.DownloadString(website+file_killswitch);
                API.OnStart(version, data_update_version, data_killswitch);
            }
        }
    }
}
