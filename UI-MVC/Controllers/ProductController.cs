using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_MVC.Models;

namespace UI_MVC.Controllers
{
    public class ProductController : Controller
    {
        readonly ProductsLogic productLogic = new ProductsLogic();
        // GET: Product
        public ActionResult Index()
        {
            List<Products> products = productLogic.GetAll();
            List<ProductView> productsView = products.Select(s => new ProductView
            {
                ProductID = s.ProductID,
                ProductName = s.ProductName,
                UnitPrice = s.UnitPrice,
                UnitsInStock = s.UnitsInStock
            }).ToList();

            return View(productsView);
        }

        public ActionResult Insert() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ProductView productView)
        {
            try
            {
                Products productEntity = new Products
                {
                    ProductName = productView.ProductName,
                    UnitPrice = productView.UnitPrice,
                    UnitsInStock = productView.UnitsInStock
                };
                productLogic.Add(productEntity);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index","Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                productLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Edit (int id, ProductView productView)
        {
            try
            {
                Products productEntity = new Products
                {
                    ProductID = id,
                    ProductName = productView.ProductName,
                    UnitPrice = productView.UnitPrice,
                    UnitsInStock = productView.UnitsInStock
                };
                productLogic.Update(productEntity);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}