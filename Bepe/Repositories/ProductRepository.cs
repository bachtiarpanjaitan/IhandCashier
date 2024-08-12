using System.Collections.ObjectModel;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;

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
            Product = new ObservableCollection<Product>(Db.Product.ToList());
        }
    }
}

