namespace Fourth.Data
{
    using Fourth.Data.Repositories;
    using Fourth.Database;

    public interface INorthwindData
    {
        NorthwindDbContext Context { get; }

        IRepository<Customer> Customers { get; }

        IRepository<Order> Orders { get; }
    }
}
