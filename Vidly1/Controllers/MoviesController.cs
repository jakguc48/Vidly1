using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Vidly1.Models;
using Vidly1.ViewModels;

namespace Vidly1.Controllers
{
    public class MoviesController : Controller
    {
        public static List<Customer> customers_v = new List<Customer>{           
            new Customer { Id = 1, Name = "John Smith" },
            new Customer { Id = 2, Name = "Marry Williams" }

        };
        // GET: Movies
        //zwraca nam akcje i zazwyczaj jest to widok, ale sa też inne możliwości.
        public ActionResult Random()
        {
            var movie_var = new Movie() {Name = "Shrek!"};
            //180803 19:40 Zamiast dodawać w argumencie widoku, korzystamy ze slownika  dodając akcje. TO JEST ZŁE PODEJŚCIE, FORGET
            //ViewData["Movie"] = movie;


            //            return Content("Hello World!"); //http://localhost:61631/movies/random daje nam rezultat
            //            return HttpNotFound(); ctrl+shift+b dla budowania bez otwierania w nowej aplikacji
            //            return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"}); //dodajemy nazwe akcji (Index) i kontroler (Home), który ma zostać wykorzystany do przekierowania, możemy też dodać anonimowy obiekt ( {} ) jako argument, który znajdzie sie w adresie strony : localhost:61631/movies/Random


            //180803 20:06 lista customers na potrzeby RandomMovieViewModel. PO tym należy nanieść zmiany w Random
            var customer_var = new List<Customer>
            {
                new Customer {Name = "Customer1"},
                new Customer {Name = "Customer2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie_var,
                Customers = customer_var
            };

            //180803 19:58 to jest najlepszy approach
            return View(viewModel);


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

        //przenosimy to co wczesniej było w routeconfig. mozliwe jest nadanie kilku constr, dla wartosci i dodatkowe mozliwosci sa wspierane jak range
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [Route("Customers")]
        public ActionResult Customers()
        {
            //var customers_v = new List<Customer>
            //{
            //    new Customer { Id = 1, Name = "John Smith" },
            //    new Customer { Id = 2, Name = "Marry Williams" }

            //};

            //customers_v.Add(new Customer {Id = 1, Name = "John Smith"});
            //customers_v.Add(new Customer { Id = 2, Name = "Marry Williams" });

            var ViewModel1 = new CustomersViewModel()
            {
                Customers = customers_v
            };

            //if (Id.HasValue)
            //{
            //    var ViewModel2 = new CustomerDetailsViewModel()
            //    {
            //        Custom = customers_v[Id.Value]
            //    };

            //    return View(ViewModel2);
            //}

                return View(ViewModel1);
            
        
         
           
        }

        [Route("Customers/Details/{id:regex(\\d)}")]
        public ActionResult Details(int Id)
        {

            var ViewModel = new CustomerDetailsViewModel()
            {
                Custom = customers_v.Find(x => x.Id.Equals(Id))
            };
            return View(ViewModel);


        }

        [Route("Movies")]
        public ActionResult Mov()
        {

            var mov_list = new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek!"},
                new Movie {Id = 2, Name = "Kung fu Panda"}
            };

            var ViewMod = new MoviesViewModel()
            {
                Movies = mov_list
                
            };
            return View(ViewMod);
        }

    }
}