using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledWebApi.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        TEntity Get(int ID);
        TEntity Get(TEntity entity);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
    }
}
