using System.Collections.ObjectModel;
using IhandCashier.Bepe.Models;

namespace IhandCashier.Bepe.Repositories
{
    public class ProductRepository
    {
        private readonly AppDbContext _db;
        private ObservableCollection<Product> Product;
        public ObservableCollection<Product> ProductCollection
        {
            get { return Product; }
            set { Product = value; }
        }

        public ProductRepository()
		{
            Product = new ObservableCollection<Product>();
            _db = BaseRepository.Context();
            GetProducts();
        }

        public void GetProducts()
        {
            //Product = new ObservableCollection<Product>_db.Product.ToList());
            Product.Add(new Product(1, "Maria Anders", "Germany", "ALFKI"));
        }
    }
}

