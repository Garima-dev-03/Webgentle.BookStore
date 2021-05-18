using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public class MovieRepository
    {
        public List<MovieModel> GetAllBooks()
        {
            return DataSource();
        }
        public MovieModel GetMovieById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<MovieModel> SearchBooks(string title, string directorName)
        {
            //return DataSource().Where(x => x.Title == title && x.Director == directorName).ToList();
            return DataSource().Where(x => x.Title.Contains(title) && x.Director.Contains(directorName)).ToList();
        }
        private List<MovieModel> DataSource()
        {
            return new List<MovieModel>()
            {
                new MovieModel(){Id = 1,Title ="Mvc",Director="Monica"},
                new MovieModel(){Id = 1,Title ="c#",Director="jane"},
                new MovieModel(){Id = 1,Title ="java",Director="harry"},


            };
        }
    }
}
