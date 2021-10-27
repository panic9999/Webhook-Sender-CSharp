using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webhook_Sender
{
    class Discord_KB_Api
    {
        public static void DiscordSendMessage(string url, string username, string content)
        {
            WebClient wc = new WebClient();
            try
            {
                wc.UploadValues(url, new NameValueCollection
            {
                {
                    "content", content
                },
                {
                    "username", username
                }
            });
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
