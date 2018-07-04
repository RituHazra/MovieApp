using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMVCWebApplication.Models;
using FirstMVCWebApplication.ViewModels;

namespace FirstMVCWebApplication.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie/Random
        public ActionResult Random()
        {
            var mv = new Movie() { Name = "Pather Panchali"};
            var customers = new List<Customer>
            {
                new Customer{ Name="Customer 1"},
                new Customer{ Name="Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = mv,
                Customers = customers
            };

            return View(viewModel);//View(mv);
            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model = mv;

            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            // return RedirectToAction("Index", "Home", new{page=1, sortBy="name"});

            //ViewData["Movie"] = mv;
            //ViewBag.RandomMovie=mv;
            //return View();
        }

        public ActionResult Edit(int i)
        {
            return Content("id=" +i);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrEmpty(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}