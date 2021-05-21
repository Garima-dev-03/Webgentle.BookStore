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
        private readonly MovieRepository _movieRepository;
        public MovieController(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
      
        public ActionResult AddToPlaylist(MovieModel movieModel)
        {
            if (movieModel.Title == null || movieModel.Director == null || movieModel.Description == null)
            {
                return View();
            }
            _movieRepository.AddToPlaylist(movieModel);
            _movieRepository.SaveChanges();
            return View();
        }

        public ViewResult GetAllMovies()
        {
            var data = _movieRepository.GetAllBooks();
            return View(data);
        }
        public ViewResult GetMovie(int id)
        {
            var dataById = _movieRepository.GetMovieById(id);
            return View (dataById);
        }
        public List<MovieModel> SearchMovies(string movieName, string directorName)
        {
            {
                return _movieRepository.SearchBooks(movieName, directorName);
            }
        }
    }
}
