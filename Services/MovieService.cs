using DemoAsPMVC.Models;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;

namespace DemoAsPMVC.Services
{
    public class MovieService
    {

        //public List<Movie> movieList { get; set; }
        private string _connextionString = @"Data Source=LAPTOP-HSV5O301;Initial Catalog=DemoAspmvc;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public MovieService()
        {
            //movieList = new List<Movie>();
            //movieList.Add(new Movie { Id = 1, Title = "Jurassic Park", Realisateur = "Steven Spielberg", Acteur = "Sam Neill", AnneeSortie = 1993 });
            //movieList.Add(new Movie { Id = 2, Title = "Alien", Realisateur = "Ridley Scott", Acteur = "Sigourney Weaver", AnneeSortie = 1979 });
            //movieList.Add(new Movie { Id = 3, Title = "Star wars IV", Realisateur = "George Lucas", Acteur = "MarK Hamill", AnneeSortie = 1977 });
            //movieList.Add(new Movie { Id = 4, Title = "AlienS", Realisateur = "Ridley Scott", Acteur = "Sigourney Weaver", AnneeSortie = 1986 });
        }

        public List<Movie> GetAll()
        {
            List<Movie> movieListDb = new List<Movie>();
            using (SqlConnection sql = new SqlConnection(_connextionString))
            {
                using (SqlCommand cmd = sql.CreateCommand())
                {
                    cmd.CommandText = "Select * FROM Movie";
                    sql.Open();
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                movieListDb.Add(new Movie
                                {
                                    Id = (int)reader["Id"],
                                    Title = (string)reader["Title"],
                                    Realisateur = (string)reader["Realisateur"],
                                    Acteur = (string)reader["Acteur"],
                                    AnneeSortie = (int)reader["AnneeDeSortie"]
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    sql.Close();
                }
            }
            return movieListDb;
        }

        public Movie GetById(int id)
        {
            
            Movie m = new Movie();
            using (SqlConnection sql = new SqlConnection(_connextionString))
            {
                using (SqlCommand cmd = sql.CreateCommand())
                {
                    cmd.CommandText = "Select * FROM Movie where Id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    sql.Open();
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                m.Id = (int)reader["Id"];
                                m.Title = (string)reader["Title"];
                                m.Realisateur = (string)reader["Realisateur"];
                                m.Acteur = (string)reader["Acteur"];
                                m.AnneeSortie = (int)reader["AnneeDeSortie"];
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    sql.Close();
                }
            }
            return m;

        }

        public void Create(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(_connextionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {

                    command.CommandText =
                "INSERT INTO Movie(title, AnneeDeSortie, Realisateur, Acteur) " +
                "VALUES( @title, @AnneeDeSortie, @Realisateur, @Acteur)";

                    // Ajouter des paramètres avec leurs valeurs
                    command.Parameters.AddWithValue("@title", movie.Title);
                    command.Parameters.AddWithValue("@AnneeDeSortie", movie.AnneeSortie);
                    command.Parameters.AddWithValue("@Realisateur", movie.Realisateur);
                    command.Parameters.AddWithValue("@Acteur", movie.Acteur);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }                    
                }
                connection.Close();
            }
        }
        public void Update(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(_connextionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {

                    command.CommandText = "Update Movie " +
                                            "SET Title = @Title," +
                                                 "Realisateur = @Realisateur," +
                                                 "AnneeDeSortie = @AnneeDeSortie," +
                                                 "Acteur = @Acteur " +
                                                 "Where Id = @Id";

                    // Ajouter des paramètres avec leurs valeurs
                    command.Parameters.AddWithValue("Id", movie.Id);
                    command.Parameters.AddWithValue("Realisateur", movie.Realisateur);
                    command.Parameters.AddWithValue("AnneeDeSortie", movie.AnneeSortie);
                    command.Parameters.AddWithValue("Acteur", movie.Acteur);
                    command.Parameters.AddWithValue("Title", movie.Title);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    
                }
                connection.Close();
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connextionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {

                    command.CommandText = "Delete Movie where Id = @Id";

                    // Ajouter des paramètres avec leurs valeurs
                    command.Parameters.AddWithValue("Id",id);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {

                        throw ex;
                    }
                }
                connection.Close();
            }
        }
    }
}
