using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary.Common
{
    public interface IProductRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int productId);
        public void Create(TEntity entity);
        public void Update(int productId, TEntity newData);
        public void Delete(int productId);
        void AddStock(int productId, int quantity);
    }
}
