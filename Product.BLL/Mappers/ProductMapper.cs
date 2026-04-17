using ProductLibrary.BLL.Entities;
using ProductLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary.BLL.Mappers
{
    public static class ProductMapper
    {
        #region Produit
        public static BLL.Entities.Product ToBLL(this DAL.Entities.Product dalProduct, IEnumerable<DAL.Entities.StockEntry> dalstockEntries)
        {
            if (dalProduct is null) throw new ArgumentNullException(nameof(dalProduct));
            var bllStockEntries = dalstockEntries
                                    .Where(entry => entry.ProductId == dalProduct.ProductId)
                                    .Select(entry => entry.ToBLL()).ToList();
            return new ProductLibrary.BLL.Entities.Product(
                dalProduct.ProductId,
                dalProduct.Name,
                dalProduct.Description,
                dalProduct.CurrentPrice,
                dalProduct.UserId,
                bllStockEntries
                );
        }
        public static DAL.Entities.Product ToDAL(this BLL.Entities.Product bllProduct)
        {
            if (bllProduct is null) throw new ArgumentNullException(nameof(bllProduct));
            return new DAL.Entities.Product()
            {
                ProductId = bllProduct.ProductId,
                Name = bllProduct.Name,
                Description = bllProduct.Description,
                CurrentPrice = bllProduct.CurrentPrice,
                UserId = bllProduct.UserId
            };
 
        }
        #endregion
    }
}
