using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_series.Repository
{
    public interface IGenericRepository<T> 
    {
        List<T> FindAll();
        T FindById(int id);
        void Create(T item);
        void Update(int id, T item);
        void Delete(int id);
        int Next();
        
    }
}
