using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess
{
    class EmployeeRepository : IRepository<Employee>
    {
        public void Create(Employee type)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee type)
        {
            throw new NotImplementedException();
        }

        public Employee Retrieve(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee type)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByCredentials(int ID, string pass)
        {
            return;
        }
    }
}
