using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

public class Program
{
    public static void Main()
    {
        var result = fac("25");
        Console.WriteLine("Result : " + result);
    }

    public static string fac(string n)
    {
        if (n == "1")
            return "1";
        return Multiply(n, fac((Convert.ToInt32(n) - 1).ToString()));
    }

    public static string Sum(List<string> list)
    {
        StringBuilder result = new StringBuilder("");
        int total = 0;
        int elde = 0;
        for (int i = list[0].Length - 1; i >= 0; i--)
        {
            total = 0;
            foreach (var item in list)
            {
                total += Convert.ToInt32(item[i].ToString());
            }

            total += elde;
            elde = total > 9 ? (int)Math.Floor((double)total / 10) : 0;
            total = i > 0 ? total % 10 : total;
            result.Insert(0, total);
        }

        return result.ToString();
    }

    ///	string olarak verilen iki sayının çarpımını yapar.
    /// Bunu, bizim kağıt üzerinde kalemle yaptığımız gibi yapar.
    /// Önce alttaki sayının birler basamağı ile yukarıdaki sayıların hepsini çarpar.
    /// Daha sonra alttaki sayının onlar basamağı ile üstteki sayının bütun basamaklarıyla çarpar.
    public static string Multiply(string a, string b)
    {
        StringBuilder result = new StringBuilder();
        int res = 0;
        int elde = 0;
        for (int i = a.Length - 1; i >= 0; i--)
        {
            result.Insert(0, "#");
            //Alttaki sayının kaçıncı basamağı ile üstteki sayının basamaklarını çarpıyorsak, ona göre sağa bir sıfır ekleriz.
            //Örneğin alttaki sayının yüzler basamağı ile üstteki sayıyı çarpıyorsak sonucun sağ tarafına önce 2 adet sıfır koyarız.
            for (int k = 0; k < (a.Length - 1 - i); k++)
                result.Insert(0, "0");
            elde = 0;
            for (int j = b.Length - 1; j >= 0; j--)
            {
                res = Convert.ToInt32(a[i].ToString()) * Convert.ToInt32(b[j].ToString()); //iki sayıyı çarp
                res += elde; // elde ekle(eğer elde yoksa değer sıfır olacağı için işlemi etkilemicektir.)
                elde = (res > 9 && j > 0) ? (int)Math.Floor((double)res / 10) : 0; // sayı 9 dan büyükse ve son basamak değilse eldeyi hesapla yoksa sıfır yap. 
                res = j > 0 ? res % 10 : res; //eğer ilk basamağa geldiysek mod almamıza gerek yok.				
                result.Insert(0, res);
            }
        }

        //Çarptığımız değerlerin toplanması için basamak değerlerini sol tarafa sıfır koyarak eşitliyoruz.
        var list = result.ToString().Split('#').ToList();
        int desiredLength = list.MaxBy(x => x.Length).Length;
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].PadLeft(desiredLength, '0');
        }

        //Çarptıklarımızın toplamlarını alıyoruz.
        string sum = Sum(list);
        return sum;
    }
}