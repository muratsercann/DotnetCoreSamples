using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullChecking
{
    public class NullableTypes
    {
        public static void MainMethod()
        {
            Person? p1 = Person.Create("Murat", "Sercan");
            Person? p2 = Person.Create("Dilek");
            Person? p3 = null;

            Console.WriteLine($"| {GetLabel(p1)} |");
            Console.WriteLine($"| {GetLabel(p2)} |");
            Console.WriteLine($"| {GetLabel(p3)} |");

            //////////////////

            Person? mann = Person.Create("Thomas", "Mann");
            Person? aristotle = Person.Create("Aristotle");

            Book faustus = Book.Create("Doctor Faustus", mann);
            Book rhetoric = Book.Create("Rhetoric", aristotle);
            Book nights = Book.Create("One Thousand and One Nights");

            var length = nights?.Author?.LastName?.Length ?? -1;
            string a1 = GetBookLabel(faustus);
            string a2 = GetBookLabel(nights);//yukarıda length değeri alırken "nights?." şeklindeki kullanım, derleyiciye burda da null olabileceğini düşündürdü.

            string GetBookLabel(Book book) =>
                GetLabel(book.Author) is string a ? $"{book.Title} by {a}" : book.Title;


            string? GetLabel(Person? person)
            {
                if (person is null) return null;
                string name = person.LastName is null ? person.FirstName : $"{person.FirstName}{person.LastName}";
                return name;
            }
        }
    }

    public class Person
    {
        public string FirstName { get; }
        public string? LastName { get; }

        private Person(string firstName, string? lastName) => (FirstName, LastName) = (firstName, lastName);

        public static Person Create(string firstName, string lastName) => new(firstName, lastName);

        public static Person Create(string name) => new Person(name, null);
    }

    public class Book
    {
        public string Title { get; }
        public Person? Author { get; }

        private Book(string title, Person? author)
        {
            Title = title;
            Author = author;
        }

        public static Book Create(string title, Person author) => new(title, author);

        public static Book Create(string title) => new Book(title, null);
    }
}
