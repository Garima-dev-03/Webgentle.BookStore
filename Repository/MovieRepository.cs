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
                new MovieModel(){Id = 1,Title ="Notebook",Director="Monica",Description ="Short description about movie"},
                new MovieModel(){Id = 1,Title ="Marvel",Director="jane",Description="Short description about movie"},
                new MovieModel(){Id = 1,Title ="Marvel",Director="jane",Description="Short description about movie"},
                new MovieModel(){Id = 1,Title ="Wonder Woman",Director="harry",Description="Short description about movie"},
                


            };
        }
    }
}
