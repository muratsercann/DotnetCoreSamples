/// <summary>
/// typeof : derleme zamanında çalışır ve typeof(<TypeName>) 
/// gibi tip adı kullanılır : typeof<string>, typeof(int), typeof(object) gibi
/// tip ad girilerek elde edilir.
/// 
/// GetType : Çalışma zamanında belirlenir. 
/// <instance></instance>.GetType() şeklinde kullanılır
/// </summary>
internal class Program
{
    private static void Main (string[] args)
    {
        Type stringType = typeof(string);//Tür adı (string,object, int gibi) kullanılır 

        string str = "Hello, World!";
        stringType = str.GetType();//instance alınmış bir tür olması gerekir.

        object obj = "I am an object string";

        //tip kontrolü
        if (obj is string)
        {
            //...
        }

        str = obj as string; //cast işlemi.
        if (str != null)
        {
            Console.WriteLine($"str: {str}");
        }

        object a = "asdasds";
        string s = (string)a;   //explicit
        a = s;                  //implicit


        //custom explicit
        CustomType sample = new CustomType(42);
        int intValue = (int)sample;

        //custom implicit
        long x = sample;
    }
}

public class CustomType
{
    public int Value { get; }

    public CustomType(int value)
    {
        Value = value;
    }

    // explicit dönüşüm operatörü tanımlanıyor
    public static explicit operator int(CustomType sample) => sample.Value;
    public static implicit operator long(CustomType sample) => sample.Value;
}