namespace Fourth.Data
{
    using Fourth.Database;
    using Repositories;
    using System;
    using System.Collections.Generic;

    public class NorthwindData : INorthwindData
    {
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        private NorthwindDbContext context;

        public NorthwindData(NorthwindDbContext context)
        {
            this.context = context;
        }

        public NorthwindDbContext Context { get; private set; }

        public IRepository<Customer> Customers => this.GetRepository<Customer>();

        public IRepository<Order> Orders => this.GetRepository<Order>();

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            Type type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                Type repositoryType = typeof(GenericRepository<T>);
                object instance = Activator.CreateInstance(repositoryType, this.context);
                this.repositories.Add(type, instance);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
