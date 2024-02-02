using System;

namespace Dotnetcore // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void passingRefOut(ref int x, out int y, in int z)
        {

            y = 89; //bu şekilde y parametresine ilk değer vermek zorundayız. Yoksa Derleme zamanı hatasına neden olur
            x++;
            y++;
            //z++; //compiler error. because you use "in" keyword before "int z"
        }
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20; // burda b'ye ne değer vermek gereksiz.
                        // Çünkü; passingRefOut çalıştırıldığında "out" keywordu ile parametre geçildiğinde
                        // içerde bir değer verilmesi zorunlu ve b nin burda verilen değeri aslında bir işe yaramaz.
            int c = 30;
            passingRefOut(ref a, out b, c);
            Console.WriteLine($"a : {a}");
            Console.WriteLine($"b : {b}");
            Console.WriteLine($"c : {c}");

        }
    }

}
