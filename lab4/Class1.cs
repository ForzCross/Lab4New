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
        public abstract AbstractSimvol CreateSimvol();
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
        public override AbstractSimvol CreateSimvol()
        {
            return new Simvol();
        }
        public override AbstractSimvol CreateExpSimvol()
        {
            return new ExpSimvol();
        }
    }
    abstract class AbstractSimvol
    {
        public abstract void SetInfo(string name, string info, Bitmap bm);

        public abstract Button CreateSimvol(Rectangle tmp);
    }
    class Simvol : AbstractSimvol
    {
        private Rectangle position_simvol = new Rectangle();

        public Bitmap bmSym;
        public string name;
        public string info;

        public override Button CreateSimvol(Rectangle tmp)
        {
            Button bt = new Button();
            position_simvol = tmp;

            bt.Location = tmp.Location;
            bt.Text = name + " " + info;
            return bt;
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

        /// <summary>
        /// вернет кнопку с инфой которую на форме уже надо будет сделать прозрачной и сделать привязку к родительской форме
        /// </summary>
        /// <param name="simvolPosition"></param>
        /// <returns></returns>
        public override Button CreateSimvol(Rectangle simvolPosition)
        {
            Button bt = new Button();
            position_simvol = simvolPosition;

            bt.Location = simvolPosition.Location;
            bt.Text = name + " " + info;
            return bt;
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