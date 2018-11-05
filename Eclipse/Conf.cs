using System;
using System.Windows.Forms;

namespace Eclipse
{
    public partial class Conf : Form
    {
        private Form1 mainForm = null;
        public Conf(Form ccForm)
        {
            InitializeComponent();
            mainForm = ccForm as Form1;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            int ttValue = Convert.ToInt32(Properties.Settings.Default.Opacity * 100.0);
            trackBar1.Value = ttValue;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double tValue = trackBar1.Value / 100.0;
            this.mainForm.Opacity = tValue;
            Properties.Settings.Default.Opacity = tValue;
            Properties.Settings.Default.Save();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.mainForm.BackColor = colorDialog1.Color;
                Properties.Settings.Default.Color = colorDialog1.Color;
                Properties.Settings.Default.Save();
            }
        }
    }
}
