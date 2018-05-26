using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess
{
    public interface IRepository<T> where T : RepositoryElement
    {
        T Create(T type);

        T Retrieve(int ID);

        void Update(T type);

        void Delete(T type);
    }
}
