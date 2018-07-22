namespace Fourth.Data.DataHandlers
{
    using Database;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerDataHandler : BaseDataHandler, ICustomerDataHandler
    {
        public CustomerDataHandler(INorthwindData data)
            : base(data)
        {
        }

        public IQueryable<Customer> All()
        {
            return this.Data.Customers.All();
        }

        public Customer GetByID(string id)
        {
            return this.Data.Customers.GetById(id);
        }

        public IEnumerable<Customer> GetByName(string name)
        {
            return this.All().Where(c => c.CompanyName.ToLower().Contains(name.ToLower()));
        }
    }
}
