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
                new MovieModel(){Id = 1,Title ="Notebook",Director="Monica",Description ="The Notebook is a 2004 American romantic drama film directed by Nick Cassavetes, written by Jeremy Leven and Jan Sardi.The film stars Ryan Gosling and Rachel McAdams as a young couple who fall in love in the 1940s. Their story is read from a notebook in the present day by an elderly man (played by James Garner), telling the tale to a fellow nursing home resident"},
                new MovieModel(){Id = 2,Title ="Marvel",Director="Jane",Description="   The Marvel Cinematic Universe (MCU) is an American media franchise and shared universe centered on a series of superhero films, independently produced by Marvel Studios and based on characters that appear in American comic books published by Marvel Comics. The franchise includes comic books, short films, television series, and digital series."},
                new MovieModel(){Id = 3,Title ="Wonder Woman",Director="Harry",Description="Wonder Woman is a superheroine appearing in American comic books published by DC Comics. ... In her homeland, the island nation of Themyscira, her official title is Princess Diana of Themyscira. When blending into the society outside of her homeland, she sometimes adopts her civilian identity Diana Prince."},
                


            };
        }
    }
}
