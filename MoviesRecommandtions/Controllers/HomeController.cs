/**************************************************************************
 *                                                                        *
 *  File:        HomeController.cs                                        *
 *  Copyright:   (c) 2021, Lupusoru Alexandru                             *
 *  E-mail:      alexandru.lupusoru@student.tuiasi.ro                     *
 *  Description: Controller that is responsible for the home view.        *
 *               The movies are fetched from DB, and if a user is         *
 *               connected movies that are recommended to him are         *
 *               displayed                                                *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/


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
using Microsoft.AspNetCore.Identity;

namespace MoviesRecommandtions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<UserPreferences> _userManager;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger, UserManager<UserPreferences> userManager)
        {           
            _context = context;
            _userManager = userManager;
        }
      
        public async Task<IActionResult> Index()
        {
            // if a user is logged in, we display only some movies, based on user preferences, from register

            List<Movie> movies = new List<Movie>();

            try
            {
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
                    //flatten the list of movies( every genre has a list of movies, we need the combine them )
                    movies = listOfLists.SelectMany(movie => movie).ToList();
                }
                else // if user has not logged in, or if its a guest, we display a generic list of movies
                {
                    movies = await _context.Movie.ToListAsync();
                }


                return View(movies);
            }
            catch(Exception ex)
            {
                return View(new ErrorViewModel { RequestId = ex.Message ?? HttpContext.TraceIdentifier });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Get filtered Movies in home 
        public async Task<IActionResult> ShowSearchResults(String SearchMovieName, String SearchWith)
        {
            try
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
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = ex.Message ?? HttpContext.TraceIdentifier });
            }
        }
        
        //handle the error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
