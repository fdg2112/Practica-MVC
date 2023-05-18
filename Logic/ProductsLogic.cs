using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure;
using Data;

namespace Logic
{
    public class ProductsLogic : BaseLogic, ICRUD<Products, int>
    {
        public ProductsLogic() { }
        public ProductsLogic (NorthwindContext context) 
        {
            _context = context;
        }

        public List<Products> GetAll()
        {
            try
            {
                return _context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de productos.", ex);
            }
        }

        public Products GetOne(int id)
        {
            try
            {
                return _context.Products.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el producto.", ex);
            }
        }

        public bool Finded(int id)
        {
            if (_context.Products.Find(id) != null) return true;
            else return false;
        }

        public void Add(Products product)
        {
            try
            {
                if (product == null) throw new ArgumentNullException("El producto no puede ser nulo");
                if (string.IsNullOrEmpty(product.ProductName)) throw new ArgumentNullException("El campo Nombre del producto no puede estar vacío");
                if (product.ProductName.Length > 40) throw new ArgumentException("El límite del campo Nombre de Producto es de 40 caracteres");
                if (product.QuantityPerUnit.Length > 20) throw new ArgumentException("El límite del campo Cantidad por Unidad es de 20 caracteres");
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al intentar agregar un producto. " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var elementToRemove = _context.Products.Find(id) ?? throw new Exception($"El producto con ID {id} no existe.");
                _context.Products.Remove(elementToRemove);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException.InnerException;
                if (innerException != null && innerException.Message.Contains("FK_"))
                {
                    var match = System.Text.RegularExpressions.Regex.Match(innerException.Message, @"(?<=tabla ')([^']*)");
                    if (match.Success)
                    {
                        string tableName = match.Value;
                        throw new Exception($"No se puede eliminar el producto porque está relacionado con la tabla {tableName}.");
                    }
                }
                throw new Exception("No se ha podido eliminar el producto.");
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido eliminar el producto. {ex.Message}");
            }
        }

        //Este delete borra los productos y sus registros asociados peeero esto no es lo recomendable...
        public void Delete2(int id)
        {
            try
            {
                var productToDelete = _context.Products.Find(id) ?? throw new Exception($"El producto con ID {id} no existe.");
                if (productToDelete.Order_Details.Count > 0)
                {
                    foreach (var orderDetail in productToDelete.Order_Details.ToList())
                    {
                        _context.Order_Details.Remove(orderDetail);
                    }
                }
                _context.Products.Remove(productToDelete);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el producto con ID {id}: {ex.Message}");
            }
        }

        public void Update(Products product)
        {
            try
            {
                if (string.IsNullOrEmpty(product.ProductName)) throw new ArgumentNullException("El campo Nombre del producto no puede estar vacío");
                if (product.ProductName.Length > 40) throw new ArgumentException("El límite del campo Nombre de Producto es de 40 caracteres");
                if (product.QuantityPerUnit.Length > 20) throw new ArgumentException("El límite del campo Cantidad por Unidad es de 20 caracteres");
                var productsUpdate = _context.Products.Find(product.ProductID);
                productsUpdate.ProductName = product.ProductName;
                productsUpdate.QuantityPerUnit = product.QuantityPerUnit;
                productsUpdate.UnitPrice = product.UnitPrice;
                productsUpdate.UnitsOnOrder = product.UnitsOnOrder;
                productsUpdate.UnitsInStock = product.UnitsInStock;
                productsUpdate.Discontinued = product.Discontinued;
                productsUpdate.SupplierID = product.SupplierID;
                productsUpdate.CategoryID = product.CategoryID;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al intentar modificar el producto. " + ex.Message);
            }
        }

    }
}
