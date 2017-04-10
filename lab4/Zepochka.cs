using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab4
{
    class Zepochka
    {
    }

    abstract class TypeOfSimvol
    {
        protected TypeOfSimvol successor;
        public void SetConnect(TypeOfSimvol successor)
        {
            this.successor = successor;
        }
        public abstract void ConcreteType(Product obj);

    }
    class ConcreteTypeOfSimvol1 : TypeOfSimvol
    {

        public override void ConcreteType(Product obj)
        {
            if (obj.name == "name")
            {
                Console.WriteLine("");
            }
            else if (successor != null)
            {
                successor.ConcreteType(obj);
            }
        }
    }
    class ConcreteTypeOfSimvol2 : TypeOfSimvol
    {

        public override void ConcreteType(Product obj)
        {
            if (obj.name == "name2")
            {
                Console.WriteLine("");
            }
            else if (successor != null)
            {
                successor.ConcreteType(obj);
            }
        }
    }
    class ConcreteTypeOfSimvol3 : TypeOfSimvol
    {

        public override void ConcreteType(Product obj)
        {
            if (obj.name == "name3")
            {
                Console.WriteLine("");
            }
            else if (successor != null)
            {
                successor.ConcreteType(obj);
            }
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
        public string info;
        public Bitmap template;
    }
    class ProductOutSimvol : Product
    {
        public ProductOutSimvol(Simvol obj) : base()
        {
            this.name = obj.name;
        }
    }
    class ProductOutExpSimvol : Product
    {
        public ProductOutExpSimvol(ExpSimvol obj) : base()
        {
            this.name = obj.name;
        }
    }
    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }
    class ProductOutSimvolCreator : Creator
    {
        Simvol ob = new Simvol();
        public ProductOutSimvolCreator(Simvol ob)
        {
            this.ob = ob;
        }
        public override Product FactoryMethod()
        {
            return new ProductOutSimvol(ob);
        }
    }
    class ProductOutExpSimvolCreator : Creator
    {
        ExpSimvol ob = new ExpSimvol();
        public ProductOutExpSimvolCreator(ExpSimvol ob)
        {
            this.ob = ob;
        }
        public override Product FactoryMethod()
        {
            return new ProductOutExpSimvol(ob);
        }
    }

}