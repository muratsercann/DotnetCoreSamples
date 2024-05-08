using System;
using System.Text;

namespace Dotnetcore 
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

        /// <summary>
        ///  İçerisine aldığı sayıları formatlı bir şekilde konsola yazar
        /// </summary>
        /// <param name="numers"></param>
        static void writeNumbers(params int[] numers)
        {
            //params parametreleri içerisine istenilen sayıda değer almak için kullanılır.
            StringBuilder sb = new StringBuilder();
            sb.Append("numbers : ");
            foreach (var item in numers)
            {
                sb.Append($"{item},");
            }
            sb.Remove(sb.Length - 1, 1);
            Console.WriteLine(sb.ToString());
        }

        static void Main(string[] args)
        {
            int a = 10;
            int b = 20; // burda b'ye ne değer vermek gereksiz.
                        // Çünkü; passingRefOut çalıştırıldığında "out" keywordu ile parametre geçildiğinde
                        // içerde bir değer verilmesi zorunlu ve b nin burda verilen değeri aslında bir işe yaramaz.
            int c = 30;
            passingRefOut(ref a, out b, in c);
            Console.WriteLine($"a : {a}");
            Console.WriteLine($"b : {b}");
            Console.WriteLine($"c : {c}");

            //params
            writeNumbers(1,2);
            writeNumbers(3,4,5,6,7,8,9,10);
        }
    }

}
