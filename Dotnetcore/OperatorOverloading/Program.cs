namespace OperatorOverloading
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            User p = new User
            {
                Username = "msercan",
                Password = "1234",
                Name = "Murat Sercan",
                Age = 31
            };
            int age = (int)p;

            UserDTO userDTO = (UserDTO)p;
            User user = (User)userDTO;

            Vektor v1 = new Vektor(1, 2);
            Vektor v2 = new Vektor(2, 7);
            Vektor v3 = v1 + v2;
            Console.WriteLine("v3 : " + v3.ToString());
        }

    }

}

