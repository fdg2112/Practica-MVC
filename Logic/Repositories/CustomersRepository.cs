using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Repositories
{
    public class CustomersRepository : BaseLogic
    {
        public List<Customers> GetAll_QuerySyntax()
        {
            return (from customer in _context.Customers
                    orderby customer.CompanyName ascending
                    select customer).ToList();
        }

        public List<Customers> GetAll_MethodSyntax()
        {
            return _context.Customers
                .OrderBy(customer => customer.CompanyName)
                .ToList();
        }

        public List<Customers> RegionWA_QuerySyntax()
        {
            return (from customer in _context.Customers
                    where customer.Region == "WA"
                    orderby customer.CompanyName ascending
                    select customer).ToList();
        }

        public List<Customers> RegionWA_MethodSyntax()
        {
            return _context.Customers
                .Where(customer => customer.Region == "WA")
                .OrderBy(customer => customer.CompanyName)
                .ToList();
        }

        public List<string> CustomersNameUpperAndLowerList_QuerySyntax()
        {
            var query = from customer in _context.Customers.ToList()
                        select $"{customer.CompanyName.ToUpper()} // {customer.CompanyName.ToLower()}";
            return query.ToList();
        }

        public List<string> CustomersNameUpperAndLowerList_MethodSyntax()
        {
            return _context.Customers
                .AsEnumerable()
                .Select(c => $"{c.CompanyName.ToUpper()} // {c.CompanyName.ToLower()}")
                .ToList();
        }


        public List<Customers> GetCustomersFromWAWithOrdersAfter1997_QuerySyntax()
        {
            return (from c in _context.Customers
                    join o in _context.Orders on c.CustomerID equals o.CustomerID
                    where c.Region == "WA" && o.OrderDate > new DateTime(1997, 1, 1)
                    select c).ToList();
        }

        public List<Customers> GetCustomersFromWAWithOrdersAfter1997_MethodSyntax()
        {
            return _context.Customers
                        .Join(_context.Orders, c => c.CustomerID, o => o.CustomerID, (c, o) => new { Customer = c, Order = o })
                        .Where(co => co.Customer.Region == "WA" && co.Order.OrderDate > new DateTime(1997, 1, 1))
                        .Select(co => co.Customer)
                        .ToList();
        }

        public List<Customers> GetFirstThreeCustomersFromWA_QuerySyntax()
        {
            return (from c in _context.Customers
                    where c.Region == "WA"
                    select c).Take(3).ToList();
        }

        public List<Customers> GetFirstThreeCustomersFromWA_MethodSyntax()
        {
            return _context.Customers
                        .Where(c => c.Region == "WA")
                        .Take(3)
                        .ToList();
        }

        public List<string> GetCustomersWithOrderCount_QuerySyntax()
        {
            var query = from c in _context.Customers
                        join o in _context.Orders on c.CustomerID equals o.CustomerID into customerOrders
                        select $"{c.CompanyName} - {customerOrders.Count()} orders";

            return query.ToList();
        }

        public List<string> GetCustomersWithOrderCount_MethodSyntax()
        {
            var query = _context.Customers
                          .GroupJoin(_context.Orders, c => c.CustomerID, o => o.CustomerID, (c, customerOrders) => new
                          {
                              Customer = c,
                              Orders = customerOrders
                          })
                          .AsEnumerable()
                          .Select(co => string.Format("{0} - {1} orders", co.Customer.CompanyName, co.Orders.Count()));

            return query.ToList();
        }

    }
}
