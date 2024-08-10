using System.Collections.ObjectModel;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Models;

namespace IhandCashier.Bepe.Repositories
{
    public class ProductRepository : BaseRepository
    {
        private ObservableCollection<Product> Product;
        public ObservableCollection<Product> ProductCollection
        {
            get => Product;
            set => Product = value;
        }

        public ProductRepository()
		{
            Product = new ObservableCollection<Product>();
            GetProducts();
        }

        public void GetProducts()
        {
            Product = new ObservableCollection<Product>(DB.Product.ToList());
        }
    }
}

