using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
namespace lab4
{
    class Zepochka
    {
    }
}

abstract class FindAndResult
{
    protected FindAndResult successor;
    public void SetConnect(FindAndResult successor)
    {
        this.successor = successor;

    }

    public abstract int FindSimbol(double res);//будем делать ифы по результат поиска рапознавания.

}

class ConcreteTypeOfSimvol1 : FindAndResult
{

    public override int FindSimbol(double res)
    {
        if (res<0.05)
        {
          
            Console.WriteLine("Я что то распознал");
            return 1;

        }
        else if (successor != null)
        {
            successor.FindSimbol(res);
            return 0;
        }
        return -1;
          
    }
}
class ConcreteTypeOfSimvol2 : FindAndResult
{

    public override int FindSimbol(double res)
    {
        if (res>=0.05)
        {
            Console.WriteLine("Я ничего не распознал");
            return 2;
        }
        else if (successor != null)
        {
            successor.FindSimbol(res);
            return 0;
        }
        return -1;
    }
}

/// <summary>
/// factorymethod for (exrsimvol and simvol) = product
/// к фабричному методу необходимо в теле мейна  добавить условие в 
/// каком режиме мы находимся эксперт или обычный человек, код слегка избыточен,
/// но это плюс к паттерну так что сойдет.
/// </summary>
abstract class Product
{
    public string name;

}
class ProductOutSimvol : Product
{

    public ProductOutSimvol(Simvol obj) : base()
    {
        this.name = obj.name;
    }
}

class ProductoutExpSimvol : Product
{
    public ProductoutExpSimvol(ExpSimvol obj) : base()
    {
        this.name = obj.name;
    }
}
abstract class Creator
{
    public abstract Product FactoryMethod();
}
class CreateProductOutSimvol : Creator
{
    Simvol ob = new Simvol();
    public CreateProductOutSimvol(Simvol ob)
    {
        this.ob = ob;
    }
    public override Product FactoryMethod()
    {
        return new ProductOutSimvol(ob);
    }
}
class CreateProductOutExpSimvol : Creator
{
    ExpSimvol ob = new ExpSimvol();
    public CreateProductOutExpSimvol(ExpSimvol ob)
    {
        this.ob = ob;
    }
    public override Product FactoryMethod()
    {
        return new ProductoutExpSimvol(ob);
    }
}

