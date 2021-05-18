using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;

namespace Webgentle.BookStore.Controllers
{ 
    public class MovieController : Controller
    {
        private readonly MovieRepository _movieRepository = null;
        public MovieController()
        {
            _movieRepository = new MovieRepository();
        }
        public ViewResult GetAllMovies()
        {
            var data = _movieRepository.GetAllBooks();
            return View();
        }
        public MovieModel GetMovie(int id)
        {
            return _movieRepository.GetMovieById(id);
        }
        public List<MovieModel> SearchMovies(string movieName, string directorName)
        {
            {
                return _movieRepository.SearchBooks(movieName, directorName);
            }
        }
    }
}
