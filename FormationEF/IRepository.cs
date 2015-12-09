using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    public interface IRepository <T>
    {
        T GetById(int id);
        // IEnumerable est une interface au dessus de List => Dc plus generique
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByLambda(Func<T, bool> where);
        T Insert(T entity);
        void Remove(T entity);
        void Save();
        //TP : faire aussi AbstractRepository
        // ==> Remplacer les List par IEnumerable
    }
}
