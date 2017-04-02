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
    class Class1
    {

    }
}
abstract class AbstractFactory
{
    public abstract AbstractSimvol CreateSimvol();
    public abstract AbstractExpSimvol CreateExpSimvol();
}
class ConcreteFactory : AbstractFactory
{
    public override AbstractSimvol CreateSimvol()
    {
        return new Simvol();
    }
    public override AbstractExpSimvol CreateExpSimvol()
    {
        return new ExpSimvol(); 
    }
}
abstract class AbstractSimvol
{
    public abstract void CreateSimvol();
}
abstract class AbstractExpSimvol
{
    public abstract void CreateExpSimol();
}
class Simvol : AbstractSimvol
{
   public Rectangle position_simvol = new Rectangle();
   public List<string> info_simvol = new List<string>();
    public override Button CreateSimvol(Rectangle tmp,string name, string info)
    {
        Button bt = new Button();
        position_simvol = tmp;
        info_simvol.Add(name);
        info_simvol.Add(info);
        bt.Location=tmp.Location;
        bt.Text = name+" "+info;
        return bt;
    }
  
}
class ExpSimvol : AbstractExpSimvol
{
    public Rectangle position_simvol = new Rectangle();
    public List<string> info_simvol = new List<string>();
    public override Button CreateSimvol(Rectangle tmp, string name, string info)
    {
        Button bt = new Button();
        position_simvol = tmp;
        info_simvol.Add(name);
        info_simvol.Add(info);
        bt.Location = tmp.Location;
        bt.Text = name + " " + info;
        return bt; //вернет кнопку с инфой которую на форме уже надо будет сделать прозрачной и сделать привязку к родительской форме
    }

}