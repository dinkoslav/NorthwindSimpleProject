namespace Fourth.Data.Repositories
{
    using Fourth.Database;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        public GenericRepository(NorthwindDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected NorthwindDbContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }
    }
}
