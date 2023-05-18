using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Repositories
{
    public class ProductsRepository : BaseLogic
    {
        public List<Products> ProductsWithOutStock_QuerySyntax()
        {
            return (from product in _context.Products
                    where product.UnitsInStock == 0
                    orderby product.ProductName ascending
                    select product).ToList();
        }

        public List<Products> ProductsWithOutStock_MethodSyntax()
        {
            return _context.Products
                .Where(product => product.UnitsInStock == 0)
                .OrderBy(product => product.ProductName)
                .ToList();
        }

        public List<Products> ProductsWithStockAndPrice_QuerySyntax()
        {
            return (from product in _context.Products
                    where product.UnitsInStock > 0 && product.UnitPrice >= 3
                    orderby product.ProductName ascending
                    select product).ToList();
        }

        public List<Products> ProductsWithStockAndPrice_MethodSyntax()
        {
            return _context.Products
                .Where(product => product.UnitsInStock > 0 && product.UnitPrice >= 3)
                .OrderBy(product => product.ProductName)
                .ToList();
        }

        public Products ProductWithId789_QuerySyntax()
        {
            return (from product in _context.Products
                    where product.ProductID == 789
                    select product).FirstOrDefault();
        }

        public Products ProductWithId789_MethodSyntax()
        {
            return _context.Products
                .Where(product => product.ProductID == 789)
                .OrderBy(product => product.ProductName)
                .FirstOrDefault();
        }

        public List<Products> GetProductsOrderedByName_QuerySyntax()
        {
            return (from p in _context.Products
                    orderby p.ProductName ascending
                    select p).ToList();
        }

        public List<Products> GetProductsOrderedByName_MethodSyntax()
        {
            return _context.Products
                        .OrderBy(p => p.ProductName)
                        .ToList();
        }

        public List<Products> GetProductsOrderedByStockInDescendingOrder_QuerySyntax()
        {
            return (from p in _context.Products
                    orderby p.UnitsInStock descending
                    select p).ToList();
        }

        public List<Products> GetProductsOrderedByStockInDescendingOrder_MethodSyntax()
        {
            return _context.Products
                            .OrderByDescending(p => p.UnitsInStock)
                            .ToList();
        }

        public List<string> GetDistinctCategories_QuerySyntax()
        {
            return (from p in _context.Products
                              select p.Categories.CategoryName)
                             .Distinct()
                             .ToList();
        }

        public List<string> GetDistinctCategories_MethodSyntax()
        {
            return _context.Products
                              .Select(p => p.Categories.CategoryName)
                              .Distinct()
                              .ToList();
        }

        public Products GetFirstProduct_QuerySyntax()
        {
            return (from p in _context.Products
                    select p).FirstOrDefault();
        }
        public Products GetFirstProduct_MethodSyntax()
        {
            return _context.Products.FirstOrDefault();
        }
    }
}
