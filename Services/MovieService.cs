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

        public Movie GetById(int id)
        {
            return movieList.Where(m => m.Id == id).SingleOrDefault();
        }

        public void Create(Movie movie)
        {
            movie.Id = movieList.Max(m => m.Id) + 1;
            movieList.Add(movie);
        }
        public Movie Update(Movie movie)
        {
            Movie existingMovie = GetById(movie.Id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Realisateur = movie.Realisateur;
                existingMovie.Acteur = movie.Acteur;
                existingMovie.AnneeSortie = movie.AnneeSortie;
                return existingMovie;
            }
            else
            {
                throw new InvalidOperationException("Movie not found.");
            }
        }
        public void Delete(int id)
        {
            movieList.Remove(GetById(id));
        }
    }
}
