using BSSL.ObjectModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSL.DomainModels
{
    public class AccountsTransactor : ITransactor<Accounts>
    {
        private readonly DbContext db;

        public AccountsTransactor(DbContext context) => db = context;

        public void Add(Accounts obj) => db.Add(obj);

        public void Delete(Accounts obj) => db.Entry(obj).State = EntityState.Deleted;

        public void Edit(Accounts obj) => db.Entry(obj).State = EntityState.Modified;

        public Task<Accounts> Find<P>(P id) => Task.Run(async () => await db.FindAsync<Accounts>(id));

        public Task<IEnumerable<Accounts>> List(byte num, byte off) => Task.Run<IEnumerable<Accounts>>(async () => await db.Set<Accounts>().OrderBy(x => x.AccountNumber).Skip(off).Take(num).ToListAsync());

        public Task Save() => Task.Run(async () => await db.SaveChangesAsync());

        public Task<IEnumerable<Accounts>> Search(string qry) => Task.Run<IEnumerable<Accounts>>(async () => await db.Set<Accounts>().Where(x => EF.Functions.Like(x.AccountNumber, $"%{qry}%")).ToListAsync());


        public bool Exists(string id) => Task.Run(async () => await Find(id)) == null;
    }
}
