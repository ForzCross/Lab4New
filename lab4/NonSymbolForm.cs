using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class NonSymbolForm : Form
    {
        public NonSymbolForm()
        {
            InitializeComponent();

            ImageDataBase DB = new ImageDataBase();
            Product[] massProd=DB.getAllImages();

            for (int i = 0; i < massProd.Count(); i++)
            {
                comboBox1.Items.Add(massProd[i].name);
            }
        }

        private void NonSymbolForm_Load(object sender, EventArgs e)
        {

        }

        private void AddFromDBButton_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            panel1.Enabled = false;

        }

        private void AddInDBButton_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            panel1.Enabled = true;
        }

        private void DoneSelectFromDBButton_Click(object sender, EventArgs e)
        {

        }

        private void DoneAddInDBButton_Click(object sender, EventArgs e)
        {

        }
    }
}
