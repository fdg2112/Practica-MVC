using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_MVC.Models;

namespace UI_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsLogic _productLogic;
        public HomeController()
        {
            _productLogic = new ProductsLogic();
        } 
        public ActionResult Index()
        {
            var productWithMaxStock = _productLogic.GetProductWithMaxStock();
            var productWithMinPrice = _productLogic.GetProductWithMinPrice();
            var productWithMinStock = _productLogic.GetProductWithMinStock();
            var mostPurchasedProduct = _productLogic.GetMostPurchasedProduct();
            var viewModel = new HomeViewModel
            {
                ProductWithMaxStock = productWithMaxStock,
                ProductWithMinPrice = productWithMinPrice,
                ProductWithMinStock = productWithMinStock,
                MostPurchasedProduct = mostPurchasedProduct
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}