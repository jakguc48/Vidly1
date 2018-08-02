﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Vidly1.Models;

namespace Vidly1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        //zwraca nam akcje i zazwyczaj jest to widok, ale sa też inne możliwości.
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"}; 
           return View(movie);
//            return Content("Hello World!"); //http://localhost:61631/movies/random daje nam rezultat
//            return HttpNotFound(); ctrl+shift+b dla budowania bez otwierania w nowej aplikacji
//            return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"}); //dodajemy nazwe akcji (Index) i kontroler (Home), który ma zostać wykorzystany do przekierowania, możemy też dodać anonimowy obiekt ( {} ) jako argument, który znajdzie sie w adresie strony : localhost:61631/movies/Random

        }

        public ActionResult Edit(int Id) //to musi być ID bo tak jest określone w RouteConfig: url: "{controller}/{action}/{id}",
        {
            return Content("Id=" + Id.ToString());
        }

        //ta akcja zwraca liste filmow z bazy danych
        public ActionResult Index(int? PageIndex, string SortBy) //jeśli indeź nie jest określony wyświetlone zostają filmy ze strony pierwszej, a jeśli sortby nie jest określony są uporządkowane po nazwie. Jeśli tworzymy opcjonalny parametr, który możę być nullable dodajemy znak zapytania
        {
            if (!PageIndex.HasValue)
            {
                PageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(SortBy))
            {
                SortBy = "Name";
            }

            return Content(String.Format("PageIndex={0}&SortBy={1}", PageIndex, SortBy));
        }

    }
}