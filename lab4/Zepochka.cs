﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Zepochka
    {
    }
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
class ConcreteTypeOfSimvo3 : TypeOfSimvol
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

}
class ProductOutSimvol : Product
{

    public ProductOutSimvol(Simvol obj) : base()
    {
        this.name = obj.info_simvol[0];
    }
}

class ProductoutExpSimvol : Product
{
    public ProductoutExpSimvol(ExpSimvol obj) : base()
    {
        this.name = obj.info_simvol[0];
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

