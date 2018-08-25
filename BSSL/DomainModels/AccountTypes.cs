using BSSL.ObjectModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSL.DomainModels
{
    public class AccountTypesTransactor : ITransactor<AccountTypes>
    {
        private readonly DbContext db;

        public AccountTypesTransactor(DbContext context) => db = context;

        public void Add(AccountTypes obj) => db.Add(obj);

        public void Delete(AccountTypes obj) => db.Entry(obj).State = EntityState.Deleted;

        public void Edit(AccountTypes obj) => db.Entry(obj).State = EntityState.Modified;

        public Task<AccountTypes> Find<P>(P id) => Task.Run(async () => await db.FindAsync<AccountTypes>(id));

        public Task<IEnumerable<AccountTypes>> List(byte num, byte off) => Task.Run<IEnumerable<AccountTypes>>(async () => await db.Set<AccountTypes>().OrderBy(x => x.AccountType).Skip(off).Take(num).ToListAsync());

        public Task Save() => Task.Run(async () => await db.SaveChangesAsync());

        public Task<IEnumerable<AccountTypes>> Search(string qry) => Task.Run<IEnumerable<AccountTypes>>(async () => await db.Set<AccountTypes>().Where(x => EF.Functions.Like(x.AccountType, $"%{qry}%")).ToListAsync());

        public bool Exists(string name)=>Task.Run(async () => await Find(name)) == null;
    }
}
