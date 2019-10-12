using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TroydonFitness.Models.Products;

namespace TroydonFitness.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {

        private readonly ProductDbContext _db;

        IDataProtector _protector;


        //private readonly ErrorViewModel _error; dependency injectio

        public ProductController(
            ProductDbContext db

          )
        {
            _db = db;

        }
        public ProductController(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("TroydonFitness.Controllers.ProductController"
                        , new string[] { "Profile1" });
        }

        //GET: /<controllers>/Products(view all types of products)
        [AllowAnonymous]
        [Route("supplements")]
        public IActionResult Index(int page = 0)
        {
            var pageSize = 2;
            var totalPosts = _db.Product.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var products =
                _db.Supplements
                    .OrderByDescending(x => x.SupplementAdded)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .ToArray();

            //returns only partial view which means only part of the page will load when the next and previous buttons clicked
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(products);
            return View(products);
        }

        //GET: /<controllers>/Products/Supplements folder root index file
        [AllowAnonymous]
        [Route("supplements")]
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

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("update")]
        public IActionResult Update()
        {
            return View();
        }

        [Route("delete")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}
