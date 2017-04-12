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
    class Facade
    {
        public void createUserWindow()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            //new SymbolSearchForm()
        }

        public void createExpertWindow()
        {
            SymbolSearchForm form = new SymbolSearchForm(Bitmap.FromFile(fileDialog.FileName), fileDialog.FileName);
            form.ShowDialog();
        }
        private Bitmap openImage()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "жипег|*.jpg|бмп|*.bmp|пенг|*.png";
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
