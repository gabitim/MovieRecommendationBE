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

namespace MoviesRecommandtions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
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
