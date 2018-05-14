using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        List<Customer> GetCustomerEntities();
        bool AddCustomer();
    }
}

