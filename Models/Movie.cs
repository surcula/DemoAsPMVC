using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DemoAsPMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int AnneeSortie { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Le nom du réalisateur doit être de minimum 1 caractère.")]
        public string Realisateur { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Le nom de l'acteur principal doit être de minimum 1 caractère.")]
        public string Acteur { get; set;}
    }
}
