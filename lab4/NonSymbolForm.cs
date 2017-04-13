using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;

namespace lab4
{
    public partial class NonSymbolForm : Form
    {
        Bitmap currentTemplate;
        Product[] massProd;
        public NonSymbolForm(Bitmap img = null)
        {
            currentTemplate = img;
            InitializeComponent();

            ImageDataBase DB = AppData.getInstance().dataBase;
            massProd=DB.getAllImages();

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
            string name = (string)comboBox1.SelectedItem;
            string info = massProd.Where((a) => a.name == name).ToArray()[0].info;
            if (currentTemplate == null)
            {
                MessageBox.Show("Отсутствиует изображение для добавления");
                return;
            }
            AppData.getInstance().dataBase.storeProduct(new Product(currentTemplate, name, info));
            Close();
        }

        private void DoneAddInDBButton_Click(object sender, EventArgs e)
        {
            string name = NameSymbolText.Text, info = InfoSymbolText.Text;
            if(currentTemplate == null)
            {
                MessageBox.Show("Отсутствиует изображение для добавления");
                return;
            }
            AppData.getInstance().dataBase.storeProduct(new Product(currentTemplate, name, info));
            Close();
        }
    }
}
