using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Webhook_Sender;
namespace Webhook_Sender
{
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
            timer1.Start();
        }
        bool coolaftersend = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked && textBox1.TextLength > 10 && richTextBox1.TextLength > 1 && textBox2.TextLength > 1 && !coolaftersend)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to send this to your Webhook?", "Webhook Sender", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var url = textBox1.Text;
                    var username = textBox2.Text;
                    var content = richTextBox1.Text;
                    var rr = url;
                    coolaftersend = true;
                    Thread.Sleep(250);
                    Discord_KB_Api.DiscordSendMessage(url, username, content);
                    Thread.Sleep(500);
                    UnCheckAll();
                    MessageBox.Show("Webhook was sended to " + rr.ToString());
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Webhook was not sended!");
                }
            }
            else
            {
                MessageBox.Show("You did something wrong!");
                if (!radioButton1.Checked)
                {
                    radioButton1.ForeColor = Color.Red;
                }
            }
        }
        private void UnCheckAll()
        {
            radioButton1.Checked = false;
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
            coolaftersend = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            API.SecurityCheck();
        }
    }
}
