using System.ComponentModel.DataAnnotations;

namespace MVCSample.Models
{
    public class Movie
    {
        public int Id { get; set; }//is required by the database for the primary key.
        public string? Title { get; set; }
        [DataType(DataType.Date)]//specifies the type of the data only as the Date.
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
