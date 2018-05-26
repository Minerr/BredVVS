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
        T Create(T element);

        T Retrieve(int ID);

        void Update(T element);

        void Delete(T element);
    }
}
