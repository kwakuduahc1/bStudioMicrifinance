using BSSL;
using BSSL.ObjectModels;
using bStudioBanker.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bStudioBanker.Repositories
{
    public class CustomersTransactor : ITransactor<Customers>
    {
        private readonly ApplicationDbContext db;

        public CustomersTransactor(ApplicationDbContext context) => db = context;

        public void Add(Customers obj) => db.Add(obj);

        public void Delete(Customers obj) => db.Entry(obj).State = EntityState.Deleted;

        public void Edit(Customers obj) => db.Entry(obj).State = EntityState.Modified;

        public Task<Customers> Find<P>(P id) => Task.Run(async () => await db.FindAsync<Customers>(id));

        public Task<IEnumerable<Customers>> List(byte num, byte off) => Task.Run<IEnumerable<Customers>>(async () => await db.Set<Customers>().OrderBy(x => x.Surname).Skip(off).Take(num).ToListAsync());

        public Task Save() => Task.Run(async () => await db.SaveChangesAsync());

        public Task<IEnumerable<Customers>> Search(string qry) => Task.Run<IEnumerable<Customers>>(async () => await db.Set<Customers>().Where(x => EF.Functions.Like(x.Surname, $"%{qry}%") || EF.Functions.Like(x.OtherNames, $"%{qry}%")).ToListAsync());

        public bool Exists(string name)=> Task.Run(async () => await Find(name)) == null;

    }
}
