using DAL.Models;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : DAL.Models.Entity
{
    //implement interface

    protected readonly DataSource DbContext;

    public BaseRepository(DataSource dbContext)
    {
        DbContext = dbContext;
    }

    public virtual void Create(TEntity entity)
    {
        DbContext.SetOf<TEntity>().Add(entity);

    }

    public virtual void Delete(TEntity entity)
    {
        DbContext.SetOf<TEntity>().Remove(entity);
    }

    public virtual void Delete(int id)
    {
        DbContext.SetOf<TEntity>().RemoveAll(x => x.Id == id);
    }

    public virtual System.Collections.Generic.IEnumerable<TEntity> Get()
    {
       return DbContext.SetOf<TEntity>();
    }

    public virtual TEntity Get(int id)
    {
        return DbContext.SetOf<TEntity>().Where(x => x.Id == id).FirstOrDefault();
    }

    public virtual void Update(TEntity entity, int id)
    {
        var temp = DbContext.SetOf<TEntity>().SingleOrDefault(x => x.Id == id);
        temp = entity;
    }
}