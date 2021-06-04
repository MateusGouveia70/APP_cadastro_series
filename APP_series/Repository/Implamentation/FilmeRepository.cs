using APP_series.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_series.Repository.Implamentation
{
    class FilmeRepository : IGenericRepository<Filme>
    {
        private List<Filme> FilmesList = new List<Filme>();
     
        public List<Filme> FindAll()
        {
            return FilmesList;
        }

        public Filme FindById(int id)
        {
            return FilmesList[id];
        }

        public void Create(Filme item)
        {
            FilmesList.Add(item);
        }

        public void Update(int id, Filme item)
        {
            FilmesList[id] = item;
        }
        public void Delete(int id)
        {
            FilmesList[id].Delete();
        }

        public int Next()
        {
            return FilmesList.Count();
        }
    }
}
