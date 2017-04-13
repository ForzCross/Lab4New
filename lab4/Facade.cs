using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace lab4
{
    /// <summary>
    /// Собирает внутри себя все подсистемы и организует их работу
    /// </summary>
    public class Facade
    {
        
        public void createUserWindow()
        {
            AppData.getInstance().isExpert = false;
            Image img = openImage();
            if (img == null)
                return;
            Bitmap bmp = new Bitmap(img);
            SymbolSearchForm form = new SymbolSearchForm(img);
            form.ShowDialog();
        }

        public void createExpertWindow()
        {
            AppData.getInstance().isExpert = true;
            Image img = openImage();
            if (img == null)
                return;
            Bitmap bmp = new Bitmap(img);
            SymbolSearchForm form = new SymbolSearchForm(img);
            form.ShowDialog();
        }

        private Image openImage()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "любой файл|*.*|жипег|*.jpg|бмп|*.bmp|пенг|*.png";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                return Bitmap.FromFile(fileDialog.FileName);
            }
            return null;
        }
    }
}

//декоратор при добавления текста к объекту симовла
//uml
