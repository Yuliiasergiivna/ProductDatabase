using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductLibrary.Common;
using ProductLibrary.DAL.Entities;


namespace ProductLibrary.DAL.Mappers
{
    public static class ProductMapper
    {
        public static Product ToProduct(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Product()
            {
                ProductId = (int)record[nameof(Product.ProductId)],
                Name = (string)record[nameof(Product.Name)],
                Description = record[nameof(Product.Description)] is DBNull ? null : (string)record[nameof(Product.Description)],
                CurrentPrice = (decimal)record[nameof(Product.CurrentPrice)],
                UserId =(Guid)record[nameof(Product.UserId)]
            };
        }
        public static StockEntry ToStockEntry(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new StockEntry()
            {
                StockEntryId = (int)record[nameof(StockEntry.StockEntryId)],
                EntryDate = (DateTime)record[nameof(StockEntry.EntryDate)],
                StockOperation = (int)record[nameof(StockEntry.StockOperation)],
                ProductId = (int)record[nameof(StockEntry.ProductId)],
                UserId = (Guid)record[nameof(StockEntry.UserId)]
            };

        }
        public static User ToUser(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new User()
            {
                UserId = (Guid)record[nameof(User.UserId)],
                Email = (string)record[nameof(User.Email)],
                Password = "*********"
            };
        }
    }
}
