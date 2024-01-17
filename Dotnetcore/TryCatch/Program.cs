using System.Linq.Expressions;
/// <summary>
/// throw;      //Stack Trace bir üste aktarılır
/// throw ex;   //Stack Trace sıfırlanır.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        MyType.Throw();
        MyType.ThrowEx();
    }
}

public static class MyType
{

    public static void Throw()
    {
        try
        {
            Divide(4, 0);
        }
        catch (Exception ex)
        {
            //Stack trace korunur.
            throw;
        }
    }

    public static void ThrowEx()
    {
        try
        {
            Divide(4, 0);
        }
        catch (Exception ex)
        {
            //Stack trace sıfırlanır.
            throw ex;
        }
    }

    public static void Divide(int a, int b)
    {
        var x = a / b;
    }

}