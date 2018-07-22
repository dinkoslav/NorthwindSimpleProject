namespace Fourth.Data.DataHandlers.Interfaces
{
    using Fourth.Database;
    using System.Collections.Generic;
    using System.Linq;

    public interface ICustomerDataHandler
    {
        IQueryable<Customer> All();

        Customer GetByID(string id);

        IEnumerable<Customer> GetByName(string name);
    }
}
