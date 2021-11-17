using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBaseContract<T>
    {
        IEnumerable<T> GetAll();


        T Create(T entity);

        void Update(T entiry);

        void Delete(T entity);

       
    }
}
