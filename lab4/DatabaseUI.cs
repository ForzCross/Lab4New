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
    public partial class DatabaseUI : Form
    {
        OpenFileDialog ofDialog = new OpenFileDialog();
        ImageDataBase db = AppData.getInstance().dataBase;
        public DatabaseUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ofDialog.ShowDialog() == DialogResult.OK)
            {
                db.storeProduct(new Product(new Bitmap(Bitmap.FromFile(ofDialog.FileName)),
                    textBox1.Text, textBox2.Text));
            }
        }
    }
}
