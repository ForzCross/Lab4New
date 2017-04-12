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

namespace lab4
{
    public partial class Form1 : Form
    {
        Facade facade = new Facade();
        public Form1()
        {
            InitializeComponent();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ЛР №4");
        }

        private void userModeButton_Click(object sender, EventArgs e)
        {
            facade.createUserWindow();
        }

        private void expertModeButton_Click(object sender, EventArgs e)
        {
            facade.createExpertWindow();
        }
    }
}
