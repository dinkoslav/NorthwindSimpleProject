namespace Fourth.Data.Repositories
{
    using System.Linq;

    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> All();

        T GetById(object id);
    }
}
