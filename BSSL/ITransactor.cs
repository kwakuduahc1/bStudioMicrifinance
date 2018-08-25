using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSSL
{
    public interface ITransactor<T> where T : class
    {
        void Add(T obj);
        void Edit(T obj);
        void Delete(T obj);
        Task<IEnumerable<T>> List(byte num = 50, byte off = 0x0);
        Task<IEnumerable<T>> Search(string qry);
        Task<T> Find<P>(P id);
        Task Save();
        bool Exists(string qry);
    }
}
