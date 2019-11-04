using AmericaVirtualApi.Contracts;
using AmericaVirtualApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _products;
        private readonly IPaginationSettings _pagination;


        public ProductService(IDatabaseSettings settings, IPaginationSettings pagination)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.ProductCollectionName);
            _pagination = pagination;
        }

        public PaginatedProducts GetPaginated()
        {
            int itemsPerPage = _pagination.ItemsPerPage;

            double totalProducts = _products.CountDocuments(p => true);
            int totalPages = Convert.ToInt32(Math.Ceiling(totalProducts / itemsPerPage));

            PaginatedProducts paginated = new PaginatedProducts();
            paginated.TotalPages = totalPages;
            paginated.Page = new List<Page>();

            for (int i = 0; i < totalPages; i++)
            {
                paginated.Page.Add(new Page()
                {
                    PageNumber = i + 1,
                    Products = _products.Find(product => true).Skip(i * itemsPerPage).Limit(3).ToList()
                });
            }

            return paginated;
        }

        public Product Get(string id)
        {
            return _products.Find<Product>(product => product.Id == id).FirstOrDefault();
        }

        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Update(string id, Product productIn)
        {
            _products.ReplaceOne(product => product.Id == id, productIn);
        }

        public void Remove(string id)
        {
            _products.DeleteOne(product => product.Id == id);
        }
    }
}
