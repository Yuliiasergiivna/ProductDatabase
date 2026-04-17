using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary.DAL.Entities
{
    public class StockEntry
    {
        public int StockEntryId { get; set; }
        public DateTime EntryDate { get; set; }
        public int StockOperation { get; set; }
      
        public int ProductId { get; set; }
        public Guid UserId { get; set; }
    }
}
