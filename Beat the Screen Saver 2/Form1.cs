using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beat_the_Screen_Saver_2
{
    public partial class Form1 : Form
    {
        bool keeprunning = false;
        public System.Threading.Thread thread;
        public Form1()
        {
            InitializeComponent();

            thread = new System.Threading.Thread(sendkey);
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;

            this.FormClosed += new FormClosedEventHandler(KillThread);
        }

        private void KillThread(object sender, EventArgs e)
        {
            keeprunning = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            keeprunning = true;
            pictureBox1.Visible = true; 
            pictureBox2.Visible = false;
            thread = new System.Threading.Thread(sendkey);
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            keeprunning = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
        }

        public void sendkey(object o)
        {
            while (keeprunning)
            {
                System.Threading.Thread.Sleep(1000);
                SendKeys.SendWait("^");
            }
        }

    }
}
