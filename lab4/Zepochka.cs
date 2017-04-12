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
using System.Drawing;
namespace lab4
{
    abstract class FindAndResult
    {
        protected FindAndResult successor;
        public void SetConnect(FindAndResult successor)
        {
            this.successor = successor;
        }
        public abstract int FindSimbol(double res);//будем делать ифы по результат поиска рапознавания.
    }


    class ResultFoundHandler : FindAndResult
    {
        public override int FindSimbol(double res)
        {
            if (res < 0.05)
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
    class ResultNotFoundHandler : FindAndResult
    {
        public override int FindSimbol(double res)
        {
            if (res >= 0.05)
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
    class Product
    {
        public string name;
        public string info;
        public Bitmap template;
        /// <summary>
        /// Создаёт продукт
        /// </summary>
        /// <param name="template">шаблон, который требуется найти на изображении</param>
        /// <param name="name">название шаблона</param>
        /// <param name="info">описание шаблона</param>
        public Product(Bitmap template, string name, string info = "")
        {
            this.template = template;
            this.name = name;
            this.info = info;
        }
        public Product() { }
    }

   
    //[УСТАРЕВШЕЕ]
    //class SimvolOutProduct : Product
    //{
    //    public SimvolOutProduct(Product obj) : base()
    //    {
    //        this.name = obj.name;
    //        this.info = obj.info;
    //        this.template = obj.template;
            
    //    }
    //}

    //class ExpSimvolOutProduct : Product
    //{
    //    public ExpSimvolOutProduct(Product obj) : base()
    //    {
    //        this.name = obj.name;
    //        this.info = obj.info;
    //        this.template = obj.template;
           
    //    }
    //}
    //[/УСТАРЕВШЕЕ]

    abstract class Creator
    {
        protected ConcreteFactory factory;
        public abstract AbstractSimvol FactoryMethod();
    }

    class SimvolOutProductCreator : Creator
    {

        public SimvolOutProductCreator(Product product)
        {
            factory = new ConcreteFactory(product);
        }
        public override AbstractSimvol FactoryMethod()
        {
            return factory.CreateSimvol();
        }

    }
    class CreateExpSimvolOutProduct : Creator
    {
        public CreateExpSimvolOutProduct(Product product)
        {
            factory = new ConcreteFactory(product);
        }
        public override AbstractSimvol FactoryMethod()
        {
            return factory.CreateExpSimvol();
        }
    }
}
