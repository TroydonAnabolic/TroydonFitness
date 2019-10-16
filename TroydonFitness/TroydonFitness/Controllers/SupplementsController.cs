using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TroydonFitness.DAL;
using TroydonFitness.Models.Products;

namespace TroydonFitness.Controllers
{
    [Route("Products")]
    public class SupplementsController : Controller
    {

        private readonly ProductDbContext _db;

        IDataProtector _protector;


        //private readonly ErrorViewModel _error; dependency injectio

        public SupplementsController(
            ProductDbContext db

          )
        {
            _db = db;

        }
        //public ProductController(IDataProtectionProvider provider)
        //{
        //    _protector = provider.CreateProtector("TroydonFitness.Controllers.ProductController"
        //                , new string[] { "Profile1" });
        //}



        //GET: /<controllers>/Products(view all types of products)
        [AllowAnonymous]
        [Route("")]
        public IActionResult Index(int page = 0)
        {
            var pageSize = 2;
            var totalPosts = _db.Products.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var products =
                _db.Products
                // TODO: Create variable that so the user can select the order by options by selecting a button on the main view
                    .OrderByDescending(x => x.Price)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .ToArray();

            //returns only partial view which means only part of the page will load when the next and previous buttons clicked
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(products);
            return View(products);
        }

        //https://localhost:44346/Products/Supplements
        //GET: /<controllers>/Products/Supplements folder root index file
        [AllowAnonymous]
        [Route("Supplements")]
        public IActionResult Products(int page = 0)
        {
            var pageSize = 2;
            var totalPosts = _db.Supplements.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var supplements =
                _db.Supplements
                    .OrderByDescending(x => x.SupplementAdded)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .ToArray();

            //returns only partial view which means only part of the page will load when the next and previous buttons clicked
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(supplements);
            return View(supplements);
        }

        //https://localhost:44346/Products/Supplements/2019
        [Route("Supplements/{year:min(2019)}/{month:range(1,12)?}/{key?}")]
        // Action to return the supplement uploaded
        public IActionResult UploadProduct(int year, string month, int day, string key)
        {
            var upload = _db.Supplements.FirstOrDefault(x => x.Key == key);

            return View(upload);
        }

        //https://localhost:44346/Products/Supplements/CreateSupplement
        [HttpGet, Route("Supplements/CreateSupplement")]
        public IActionResult CreateSupplement()
        {
            return View();
        }

        [HttpPost, Route("Supplements/CreateSupplement")]
        public IActionResult CreateSupplement(Supplement upload)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // override fields that the user submitted
            upload.Administrator = User.Identity.Name; //change to admin name
            upload.SupplementAdded = DateTime.Now;

            // Save to the database
            _db.Supplements.Add(upload);
            _db.SaveChanges();

            // Redirect to newly created comment.
            return RedirectToAction("UploadProduct", "Supplement", new
            {
                year = upload.SupplementAdded.Year,
                month = upload.SupplementAdded.Month,
                key = upload.Key
            });
        }

        [Route("supplements/update")]
        public IActionResult Update()
        {
            return View();
        }

        [Route("supplements/delete")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}
