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
    abstract class AbstractFactory
    {
        public abstract AbstractSimvol CreateSimvol(Rectangle aa);
        public abstract AbstractSimvol CreateExpSimvol();
    }
    /// <summary>
    /// Фабрика, создаёт из продукта символы
    /// </summary>
    class ConcreteFactory : AbstractFactory
    {
        Product baseProduct;
        public ConcreteFactory(Product product)
        {
            baseProduct = product;
        }
        public ConcreteFactory() { }
        public override AbstractSimvol CreateSimvol(Rectangle aa)
        {
            Simvol tempSimvol=Simvol.CreateSimvol(aa);
            tempSimvol.SetInfo(baseProduct.name,baseProduct.info,baseProduct.template);
            tempSimvol.infoButton.Text = tempSimvol.name;
            tempSimvol.infoButton.BackColor = Color.FromArgb(0, 255, 255, 255);
            tempSimvol.infoButton.Click += (a, b) => MessageBox.Show(tempSimvol.info);
            tempSimvol.infoButton.ForeColor = Color.Red;
            tempSimvol.infoButton.Font = new Font(FontFamily.Families[0], 20);
            return tempSimvol;
        }
        public override AbstractSimvol CreateExpSimvol()
        {
            return new ExpSimvol();
        }
    }
    abstract class AbstractSimvol
    {
        public abstract void SetInfo(string name, string info, Bitmap bm);

        static public Simvol CreateSimvol(Rectangle tmp) { return null; }
    }
    class Simvol : AbstractSimvol
    {
        private Simvol()
        {

        }
        //private Rectangle position_simvol = new Rectangle();
        public Button infoButton = new Button();
        public Bitmap bmSym;
        public string name;
        public string info;
        static public Simvol CreateSimvol(Rectangle tmp)
        {
            Simvol  sim= new Simvol();

            sim.infoButton.Bounds=tmp;
            return sim;
        }
        public override void SetInfo(string name, string info, Bitmap bm)
        {
            bmSym = bm;
            this.name = name;
            this.info = info;
        }
    }
    class ExpSimvol : AbstractSimvol
    {
        public string name;
        public string info;
        private Bitmap template;
        public Rectangle position_simvol = new Rectangle();
        private Button infoButton;
        /// <summary>
        /// вернет кнопку с инфой которую на форме уже надо будет сделать прозрачной и сделать привязку к родительской форме
        /// </summary>
        /// <param name="simvolPosition"></param>
        /// <returns></returns>
        static public ExpSimvol CreateSimvol(Rectangle tmp)
        {
            ExpSimvol sim = new ExpSimvol();

            sim.infoButton.Bounds = tmp;
            return sim;
        }
        public override void SetInfo(string name, string info, Bitmap template)
        {
            this.name = name;
            this.info = info;
            this.template = template;
        }
        public void updateInfo(string name, string info)
        {
            this.name = name;
            this.info = info;
        }
    }

}