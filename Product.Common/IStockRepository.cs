using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary.Common
{
    public interface IStockRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity? Get(int stockEntryId);
        public void Create(TEntity entity);
        public void Update(int stockEntryId, TEntity newData);
        public void Delete(int stockEntryId);
    
    }
}
