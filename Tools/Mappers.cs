using DemoAsPMVC.Models;
using Dal = AspDal.Entityes_DAO_Models_DTO;

namespace DemoAsPMVC.Tools
{
    public static class Mappers
    {
        public static Dal.Movie ToDal( this MovieCreateForm movieCreateForm)
        {
            return new Dal.Movie
            {
                Title = movieCreateForm.Title,
                RealisateurId = movieCreateForm.RealisateurId,
                Description = movieCreateForm.Description,
            };
        }

        public static Dal.Movie ToDal(this MovieEditForm movieCreateForm)
        {
            return new Dal.Movie
            {
                Id = movieCreateForm.Id,
                Title = movieCreateForm.Title,
                RealisateurId = movieCreateForm.RealisateurId,
                Description = movieCreateForm.Description,
            };
        }

        public static Movie ToAsp(this Dal.Movie m)
        {
            return new Movie
            {
                Id = m.Id,
                Title = m.Title,
                RealisateurId = m.RealisateurId,
                Description = m.Description,
            };
        }

        //public static MovieEditForm ToEditForm(this Movie m)
        //{
        //    return new MovieEditForm
        //    {
        //        Id = m.Id,
        //        Title = m.Title,
        //        Realisateur = m.Realisateur,
        //        AnneeSortie = m.AnneeSortie,
        //        Acteur = m.Acteur
        //    };
        //}


        public static MovieEditForm ToEditForm(this Dal.Movie m)
        {
            return new MovieEditForm
            {
                Id = m.Id,
                Title = m.Title,
                RealisateurId = m.RealisateurId,
                Description = m.Description,
            };
        }


        public static Dal.Movie ToDal(this Movie m)
        {
            return new Dal.Movie
            {
                Id = m.Id,
                Title = m.Title,
                RealisateurId = m.RealisateurId,
                Description = m.Description,
            };
        }

    }
}
