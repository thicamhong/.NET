using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        private FormationEFEntities entities { get; } = new FormationEFEntities();


        public IEnumerable<T> GetAll()
        {
            // entities.Set<Book>() = entities.Books => Set<T>() est beaucoup plus generique
            return entities.Set<T>();
        }


        public T GetById(int id)
        {
            return entities.Set<T>().Find(id);
        }


        public IEnumerable<T> GetByLambda(Func<T, bool> where)
        {
            return entities.Set<T>().Where(where);
        }


        public T Insert(T entity)
        {
            entities.Set<T>().Add(entity);

            return entity;
        }


        public void Remove(T entity)
        {
            entities.Set<T>().Remove(entity);
            
        }


        public void Save()
        {
            entities.SaveChanges();
        }


        
    }
}
