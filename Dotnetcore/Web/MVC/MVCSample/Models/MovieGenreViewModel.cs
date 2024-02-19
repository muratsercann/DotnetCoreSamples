using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCSample.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie>? Movies { get; set; }

        
        public SelectList? Genres { get; set; }

        [Display(Name = "Genre : ")]
        public string? MovieGenre { get; set; }
        [Display(Name = "Title : ")]
        public string? SearchString { get; set; }

        public string? GetMovieGenreLabelName()
        {
            return nameof(MovieGenre);
        }
    }
}
