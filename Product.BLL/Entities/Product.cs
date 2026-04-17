using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary.BLL.Entities
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        private string? _description;
        public string? Description 
        { 
            get => _description; 
            private set
            {
                if (value is not null && value.Length > 512)
                {
                    throw new ArgumentException("Description cannot exceed 512 characters.");
                }
                _description = value;
            }
        }
        public decimal CurrentPrice { get; private set; }
        public Guid UserId { get; private set; }

        public int TotalStock { get {
            return StockEntries.Sum(s => s.StockOperation);
            } 
        }

        //public Product() { }
        //Create
        public Product( string name, string? description, decimal currentPrice, Guid userId)
        {
  
            Name = name;
            Description = description;
            CurrentPrice = currentPrice;
            UserId = userId;
        }

        //public Product(int totalStock)
        //{
        //    TotalStock = totalStock;
        //    if(totalStock <0 )
        //        {
        //        throw new ArgumentException("Total stock cannot be negative.");
        //    }
        //}
        public IEnumerable<StockEntry> StockEntries { get; set; } = new List<StockEntry>();
        //Update
        public Product(int productId, string name, string? description, decimal currentPrice, Guid userId)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            CurrentPrice = currentPrice;
            UserId = userId;
        }

        public Product(int productId, string name, string description, decimal currentPrice, Guid userId, IEnumerable<StockEntry> entries) : this(productId, name, description, currentPrice, userId)
        {
            StockEntries = entries;
        }

        public Product(string name, string? description, decimal currentPrice)
        {
            Name = name;
            Description = description;
            CurrentPrice = currentPrice;
        }
    }
}
