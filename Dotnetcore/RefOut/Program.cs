using System;

namespace Dotnetcore // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void passingRefOut(ref int x, out int y)
        {
            y = 89; //bu şekilde y parametresine ilk değer vermek zorundayız. Yoksa Derleme zamanı hatasına neden olur
            x++;
            y++;
        }
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20; // burda b'ye ne değer vermek gereksiz.
                        // Çünkü; passingRefOut çalıştırıldığında out keywordu ile parametre geçildiğinde
                        // içerde bir değer verilmesi zorunlu ve b nin burda verilen değeri geçersizdir.

            passingRefOut(ref a, out b);
            Console.WriteLine("a : " + a);
            Console.WriteLine("b : " + b);

        }
    }

}
