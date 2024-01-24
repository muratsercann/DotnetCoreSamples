class Program
{
    static void Main()
    {

        MutablePerson p1 = new MutablePerson() { Name = "Murat", Surname = "Sercan" };
        MutablePerson p2 = p1;
        p2.Name = "Dilek";  //p1 affected
        Console.WriteLine(p1.FullName);//Dilek Sercan

        ImmutablePerson p3 = new ImmutablePerson("Murat", "Sercan");
        ImmutablePerson p4 = p3.WithNewName("Malik", "Masis"); //p3 not affected
        Console.WriteLine(p3.FullName);//Murat Sercan

        int a = 5;
        int b = a;
        b++;//a not affected


    }
}

class MutablePerson
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public string FullName
    {
        get
        {
            return $"{Name} {Surname}";
        }
    }
}

class ImmutablePerson
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public string FullName
    {
        get
        {
            return $"{Name} {Surname}";
        }
    }

    public ImmutablePerson(string name, string surname)
    {
        this.Name = name;
        this.Surname = surname;
    }

    public ImmutablePerson WithNewName(string newName, string newSurname)
    {
        return new ImmutablePerson(newName, newSurname);
    }

}