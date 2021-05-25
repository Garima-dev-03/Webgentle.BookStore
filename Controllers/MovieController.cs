using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

        
        public ActionResult AddToPlaylist()
        {
          
            return View();
        }

        [HttpPost]
        [Authorize]
        public  ActionResult AddToPlaylist(MovieModel movieModel)
        {
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

        [Authorize]
        public ActionResult Delete(int id)
         {
          _movieRepository.Delete(id);
          _movieRepository.SaveChanges();
          return RedirectToAction("GetAllMovies");
         }
        
       
        
    }
}
