using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    public class User
    {
        public int Id;
        public string Username = string.Empty;
        public string Password = string.Empty;
        public string Name = string.Empty;
        public int Age = 0;

        public static explicit operator int(User p) => p.Age;

        public static explicit operator UserDTO(User p) =>
            new UserDTO
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age
            };

        public static explicit operator User(UserDTO p) =>
            new User
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age,
            };

    }

    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }


}
