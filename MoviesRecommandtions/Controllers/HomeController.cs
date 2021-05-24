using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesRecommandtions.Models;
using MoviesRecommandtions.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MoviesRecommandtions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        private readonly UserManager<UserPreferences> _userManager;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger, UserManager<UserPreferences> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

       
        public async Task<IActionResult> Index()
        {
            List<Movie> movies = new List<Movie>();
            var userDetails = await _userManager.GetUserAsync(User);

            if (userDetails != null)
            {
                var favouritveGenres = userDetails.Preferences.Split(",");
                List<List<Movie>> listOfLists = new List<List<Movie>>();
                for (int i = 0; i < favouritveGenres.Length; i++)
                {
                    List<Movie> moviesFromOneGenre = new List<Movie>();
                    moviesFromOneGenre = await _context.Movie.Where(movie => movie.Category.Contains(favouritveGenres[i])).ToListAsync();
                    listOfLists.Add(moviesFromOneGenre);
                }
                movies = listOfLists.SelectMany(movie => movie).ToList();
            }
            else
            {
                movies = await _context.Movie.ToListAsync();
            }


            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Get filtered Movies in index 
        public async Task<IActionResult> ShowSearchResults(String SearchMovieName, String SearchWith)
        {
            if (SearchWith.Equals("Name"))
            {
                return View("Index", await _context.Movie.Where(m => m.Name.Contains(SearchMovieName)).ToListAsync());
            }
            else if (SearchWith.Equals("Genre"))
            {
                return View("Index", await _context.Movie.Where(m => m.Category.Contains(SearchMovieName)).ToListAsync());
            }
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
