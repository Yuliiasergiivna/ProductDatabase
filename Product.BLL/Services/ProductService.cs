using ProductLibrary.BLL.Entities;
using ProductLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductLibrary.BLL.Mappers;
using ProductLibrary.DAL.Entities;
using ProductLibrary.Common;

namespace ProductLibrary.BLL.Services
{
    public class ProductService :
        IProductRepository<Entities.Product>
        
    {
        private readonly IProductRepository<DAL.Entities.Product> _dalService;
        private readonly IStockRepository<DAL.Entities.StockEntry> _stockService;

        public ProductService(
            IProductRepository<DAL.Entities.Product> dalService, IStockRepository<DAL.Entities.StockEntry> stockService)
        {
            _dalService = dalService;
            _stockService = stockService;
        }

        public void AddStock(int productId, int quantity)
        {
            var entry = new Entities.StockEntry(0, DateTime.Now, quantity, productId);
            _stockService.Create(entry.ToDAL());
        }

        public void Create(Entities.Product bllProduct)
        {
            _dalService.Create(bllProduct.ToDAL());
        }

        public void Delete(int productId)
        {
            _dalService.Delete(productId);
        }

        public IEnumerable<Entities.Product> Get()
        {
            var dalProducts = _dalService.Get();
            var stockEntries = _stockService.Get();
            return dalProducts.Select(dalProduct => dalProduct.ToBLL(stockEntries));
        }

        public Entities.Product Get(int productId)
        {
            var dalProduct = _dalService.Get(productId);
            var allStockEntries = _stockService.Get();
            return dalProduct.ToBLL(allStockEntries);
        }

        public void Update(int productId, Entities.Product newData)
        {
            _dalService.Update(productId, newData.ToDAL());
        }
    }
}
