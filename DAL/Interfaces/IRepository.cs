using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public interface IRepository<TEntity> where TEntity:Entity
    {
        IEnumerable<TEntity> Get();

        TEntity Get(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(int id);
    }
}
