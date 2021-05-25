/**************************************************************************
 *                                                                        *
 *  File:        MoviesController.cs                                      *
 *  Copyright:   (c) 2021, Hartan Mihai-Silviu                            *
 *  E-mail:      silviuhartan10@gmail.com                                 *
 *  Description: Controller that is responsible for the movies view.      *
 *               Normally this view is only accessible to some elevated   *
 *               type of user who can add, edit details, or delete        *
 *               a movie                                                  *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesRecommandtions.Data;
using MoviesRecommandtions.Models;

namespace MoviesRecommandtions.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET Movies
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Movies/ShowSearchForm
        [Authorize]
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: Movies/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SelectSearch, String SearchWith)
        {
            try
            {
                if (SearchWith.Equals("Name"))
                {
                    return View("Index", await _context.Movie.Where(m => m.Name.Contains(SelectSearch)).ToListAsync());
                }
                else if (SearchWith.Equals("Genre"))
                {
                    return View("Index", await _context.Movie.Where(m => m.Category.Contains(SelectSearch)).ToListAsync());
                }

                return View("Index");
            }
            catch(Exception ex)
            {
                return View(new ErrorViewModel { RequestId = ex.Message ?? HttpContext.TraceIdentifier });
            }
            
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var movie = await _context.Movie
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (movie == null)
                {
                    return NotFound();
                }

                return View(movie);
            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = ex.Message ?? HttpContext.TraceIdentifier });
            }
            
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count() > 0)
                    {
                        byte[] p1 = null;
                        using (var fs1 = files[0].OpenReadStream())
                        {
                            using (var ms1 = new MemoryStream())
                            {
                                fs1.CopyTo(ms1);
                                p1 = ms1.ToArray();
                            }
                        }
                        movie.Banner = p1;
                    }
                    _context.Add(movie);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(movie);
            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = ex.Message ?? HttpContext.TraceIdentifier });
            }
           
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var movie = await _context.Movie.FindAsync(id);
                if (movie == null)
                {
                    return NotFound();
                }
                return View(movie);
            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = ex.Message ?? HttpContext.TraceIdentifier });
            }
            
        }

        // POST: Movies/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count() > 0)
                    {
                        byte[] p1 = null;
                        using (var fs1 = files[0].OpenReadStream())
                        {
                            using (var ms1 = new MemoryStream())
                            {
                                fs1.CopyTo(ms1);
                                p1 = ms1.ToArray();
                            }
                        }
                        movie.Banner = p1;
                    }
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return View(new ErrorViewModel { RequestId = ex.Message ?? HttpContext.TraceIdentifier });
                    }
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var movie = await _context.Movie
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (movie == null)
                {
                    return NotFound();
                }

                return View(movie);
            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = ex.Message ?? HttpContext.TraceIdentifier });
            }
            
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var movie = await _context.Movie.FindAsync(id);
                _context.Movie.Remove(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = ex.Message ?? HttpContext.TraceIdentifier });
            }
            
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    } 
}
