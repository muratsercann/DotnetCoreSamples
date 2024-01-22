internal class Program
{
    private static void Main(string[] args)
    {
        string s1 = "murat";
        string s2 = "murat";
        Console.WriteLine($"string s1               : {s1}");
        Console.WriteLine($"string s2               : {s2}");
        Console.WriteLine($"s1 == s2                : {s1 == s2}");
        Console.WriteLine($"s1.Equals(s2)           : {s1.Equals(s2)}");
        Console.WriteLine($"ReferenceEquals(s1,s2)  : {ReferenceEquals(s1, s2)}");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("--------------------------------------");

        int i1 = 1;
        int i2 = 1;
        Console.WriteLine($"int i1                  : {i1}");
        Console.WriteLine($"int i2                  : {i2}");
        Console.WriteLine($"i1 == i2                : {i1 == i2}");
        Console.WriteLine($"i1.Equals(i2)           : {i1 == i2}");
        Console.WriteLine($"ReferenceEquals(i1,i2)  : {ReferenceEquals(i1, i2)}");

        Console.WriteLine("--------------------------------------");
        Console.WriteLine("--------------------------------------");
        object a = 1;
        object b = 1;
        Console.WriteLine($"object a                : {a}");
        Console.WriteLine($"object b                : {b}");
        Console.WriteLine($"a == b                  : {a == b}");
        Console.WriteLine($"a.Equals(b)             : {a.Equals(b)}");
        Console.WriteLine($"ReferenceEquals(a,b)    : {ReferenceEquals(a, b)}");

        Console.WriteLine("--------------------------------------");
        Console.WriteLine("--------------------------------------");
        string s3 = "murat";
        string s4 = "sercan";
        string s5 = "muratsercan";
        Console.WriteLine($"string s3                                   :  {s3}");
        Console.WriteLine($"string s4                                   :  {s4}");
        Console.WriteLine($"string s5                                   :  {s5}");
        Console.WriteLine($"s5.Equals('muratsercan')                    :  {s5.Equals("muratsercan")}");
        Console.WriteLine($"s5.Equals(s3+s4)                            :  {s5.Equals(s3 + s4)}");
        Console.WriteLine($"s5.Equals(string.Intern(s3 + s4))           :  {s5.Equals(string.Intern(s3 + s4))}");
        Console.WriteLine($"ReferenceEquals(s5,'muratsercan')           :  {ReferenceEquals(s5, "muratsercan")}");
        Console.WriteLine($"ReferenceEquals(s5,s3+s4)                   :**{ReferenceEquals(s5, (s3 + s4))}**");
        Console.WriteLine($"ReferenceEquals(s5,string.Intern(s3 + s4))  :**{ReferenceEquals(s5, string.Intern(s3 + s4))}**");


        Console.WriteLine("-------------------------------------------------------------------------------");
        Console.WriteLine("                              * RESULT *                                       ");
        Console.WriteLine("-------------------------------------------------------------------------------");
        Console.WriteLine("'=='                     : compares 'values' for the value type and the'adresses' for the reference type                   ");
        Console.WriteLine("'Equals'                 : first, compares 'adresses'. if they are not the same , then compares 'values'");
        Console.WriteLine("'ReferenceEquals'        : compares 'adresses' for all types   ");
        Console.WriteLine();
        Console.WriteLine("* string is immutable (the same value on the same adress, the different value on the different adress)");
        Console.WriteLine("* integer is mutable  (the same value on the different adress)");
        Console.WriteLine();

        /*Console.Write("type value : ");
        var c = Console.ReadLine();
        Console.WriteLine($"c.Equals(s1)          :{c.Equals(s1)}");
        Console.WriteLine($"ReferenceEquals(c,s1) :{ReferenceEquals(c, s1)} ");*/
    }
}