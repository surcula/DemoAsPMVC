using System.ComponentModel.DataAnnotations;

namespace DemoAsPMVC.Models
{
    public class MovieCreateForm
    {
        public string Title { get; set; }
        public int RealisateurId { get; set; }
        public string Description { get; set; }
        public Personnes Realisateur { get; set; }
        public List<Acteur> Acteurs { get; set; }
    }
}
