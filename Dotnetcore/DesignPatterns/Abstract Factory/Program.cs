using System;

/// <summary>
/// MainApp startup class for Real-World 
/// Factory Method Design Pattern.
/// </summary>

class Program
{
    /// <summary>
    /// Entry point into console application.
    /// </summary>

    static void Main()
    {
        Factory fac = new ModernFactory();
        Factory victorianFac = new VictorianFactory();

        var chair = fac.CreateChair();
        var table = fac.CreateTable();
        var sofa = victorianFac.CreateSofa();

        Console.WriteLine($"{chair.GetType()}");
        Console.WriteLine($"{table.GetType()}");
        Console.WriteLine($"{sofa.GetType()}");
    }
}

public abstract class Chair { }

public abstract class Sofa { }

public abstract class Table { }

//Chair
public class ModernChair : Chair { }

public class VictorianChair : Chair { }

public class ArtDecoChair : Chair { }

//Sofa
public class ModernSofa : Sofa { }

public class VictorianSofa : Sofa { }

public class ArtDecoSofa : Sofa { }

//Table
public class ModernTable : Table { }

public class VictorianTable : Table { }

public class ArtDecoTable : Table { }

//Factories
public abstract class Factory
{
    public abstract Chair CreateChair();
    public abstract Sofa CreateSofa();
    public abstract Table CreateTable();
}

//Modern Factory
public class ModernFactory : Factory
{
    public override Chair CreateChair()
    {
        return new ModernChair();
    }

    public override Sofa CreateSofa()
    {
        return new ModernSofa();
    }

    public override Table CreateTable()
    {
        return new ModernTable();
    }

}

//Victorian Factory
public class VictorianFactory : Factory
{
    public override Chair CreateChair()
    {
        return new VictorianChair();
    }

    public override Sofa CreateSofa()
    {
        return new VictorianSofa();
    }

    public override Table CreateTable()
    {
        return new VictorianTable();
    }

}

//ArtDeco Factory
public class ArtDecoFactory : Factory
{
    public override Chair CreateChair()
    {
        return new ArtDecoChair();
    }

    public override Sofa CreateSofa()
    {
        return new ArtDecoSofa();
    }

    public override Table CreateTable()
    {
        return new ArtDecoTable();
    }

}