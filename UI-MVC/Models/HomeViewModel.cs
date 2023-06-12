using Entities;

namespace UI_MVC.Models
{
    public class HomeViewModel
    {
        public Products ProductWithMaxStock { get; set; }
        public Products ProductWithMinPrice { get; set; }
        public Products ProductWithMinStock { get; set; }
        public Products MostPurchasedProduct { get; set; }
    }
}