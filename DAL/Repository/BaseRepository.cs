public class BaseRepository:IRepository<TEntity>
{
    //implement interface

    protected readonly DataSource DbContext;

    public BaseRepository(DataSource dbContext)
    {
        DbContext = dbContext;
    }
}