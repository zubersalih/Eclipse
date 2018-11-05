using System;
using System.Windows.Forms;

using System.Collections.Specialized;

using System.Runtime.InteropServices;

namespace Eclipse
{
   
    public partial class Form1 : Form
    {

    private Conf configForm;

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Properties.Settings.Default.Color;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           DllHelper.SetWindowLong(this.Handle, DllHelper.GWL.ExStyle, DllHelper.WS_EX.Transparent | DllHelper.WS_EX.Layered);
            
        }
      
        public static bool IsKeyDown(Keys key)
        {
            return (DllHelper.GetKeyState(Convert.ToInt16(key)) & 0X80) == 0X80;
        }
        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (IsKeyDown(Keys.LWin) && IsKeyDown(Keys.LShiftKey))
            {
                configForm = new Conf(this);
                configForm.Show();
            }
        }
        private void openConf()
        {
            bool isConfOpen = false;
            configForm = new Conf(this);
            foreach (Form forms in Application.OpenForms)
            {
                if(forms.Text == "Configuration")
                {
                    isConfOpen = true;
                    configForm.BringToFront();
                    break;
                }
            }
            if(!isConfOpen)
            {
                configForm.Show();
            }
            
            
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openConf();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
