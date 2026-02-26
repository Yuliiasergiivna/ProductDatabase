using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary.BLL.Entities
{
    public class StockEntry
    {
        public int StockEntryId { get; private set; }
        public DateTime EntryDate { get; private set; }
        public int StockOperation { get; private set; }
        public int ProductId { get; private set; }

        public StockEntry(int stockEntryId, DateTime entryDate, int stockOperation, int productId)
        {
            StockEntryId = stockEntryId;
            EntryDate = entryDate;
            StockOperation = stockOperation;
            ProductId = productId;
        }
    }
}
