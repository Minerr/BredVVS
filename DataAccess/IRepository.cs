using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<T> 
    {
        T Create(T type);

        T Retrieve(int ID);

        void Update(T type);

        void Delete(T type);
    }
}
