using DemoAsPMVC.Models;

namespace DemoAsPMVC.Services
{
    public  class MovieService
    {

        public  List<Movie> movieList { get; set; }
        public MovieService()
        {
            movieList = new List<Movie>();
            movieList.Add(new Movie { Id = 1, Title = "Jurassic Park", Realisateur = "Steven Spielberg", Acteur = "Sam Neill", AnneeSortie = 1993 });
            movieList.Add(new Movie { Id = 2, Title = "Alien", Realisateur = "Ridley Scott", Acteur = "Sigourney Weaver", AnneeSortie = 1979 });
            movieList.Add(new Movie { Id = 3, Title = "Star wars IV", Realisateur = "George Lucas", Acteur = "MarK Hamill", AnneeSortie = 1977 });
            movieList.Add(new Movie { Id = 4, Title = "AlienS", Realisateur = "Ridley Scott", Acteur = "Sigourney Weaver", AnneeSortie = 1986 });
        }
    }
}
