using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Security.Principal;

namespace PasswordEdit
{
    public partial class Form1 : Form
    {
     
        public void ShowUsers()
        {
            ProcessStartInfo showUsers = new ProcessStartInfo("net","user");
            showUsers.UseShellExecute = false;
            showUsers.RedirectStandardOutput = true;
            showUsers.CreateNoWindow = true;
            var proc = Process.Start(showUsers);
            string resultProcess = proc.StandardOutput.ReadToEnd();
            textBoxConsole.Text = resultProcess;      
        }

        public void EditPassword()
        {
            string arg =" user "+textBoxUsername.Text + " *";
            string cmd = "net";
            
            ProcessStartInfo editPass = new ProcessStartInfo(cmd,arg);
            editPass.UseShellExecute = false;
            editPass.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            editPass.Verb = "runas";
            var proc = Process.Start(editPass);
            textBoxConsole.Text = "Edit password on process...."; 
          
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonShowUser_Click(object sender, EventArgs e)
        {
           ShowUsers();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text.Equals(""))
            {
                MessageBox.Show("Please enter Valid username");
                ShowUsers();
            }
            else
            {
                EditPassword();
            }
            
        }
    }
}
