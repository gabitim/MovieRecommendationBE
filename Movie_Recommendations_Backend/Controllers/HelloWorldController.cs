using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_Recommendations_Backend.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ViewResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public ViewResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}