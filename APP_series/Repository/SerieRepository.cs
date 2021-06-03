using APP_series.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_series.Repository
{
    class SerieRepository : IRepository<Serie>
    {
        private List<Serie> SeriesList = new List<Serie>();

        public List<Serie> FindAll()
        {
            return SeriesList;
        }

        public Serie FindById(int id)
        {
            return SeriesList[id];
        }

        public void Create(Serie item)
        {
            SeriesList.Add(item);
        }

        public void Update(int id, Serie item)
        {
            SeriesList[id] = item;
        }

        public void Delete(int id)
        {
            SeriesList[id].Delete();
        }     

        public int Next()
        {
            return SeriesList.Count;
        }

        
    }
}
