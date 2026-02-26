using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary.BLL.Mappers
{
    public static class StockEntryMapper
    {
        public static BLL.Entities.StockEntry ToBLL(this DAL.Entities.StockEntry dalEntry)
        {
            if (dalEntry is null) return null;

            return new BLL.Entities.StockEntry(
                dalEntry.StockEntryId,
                dalEntry.EntryDate,
                dalEntry.StockOperation,
                dalEntry.ProductId
            );
        }
        public static DAL.Entities.StockEntry ToDAL(this BLL.Entities.StockEntry bllEntry)
        {
            if (bllEntry is null) return null;

            return new DAL.Entities.StockEntry()
            {
                EntryDate = bllEntry.EntryDate,
                StockOperation = bllEntry.StockOperation,
                ProductId = bllEntry.ProductId
            };
        }
    }
}
