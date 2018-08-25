using BSSL.ObjectModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSSL.DomainModels
{
    public class TransactionsTransactor : ITransactor<AccountsTransactions>
    {
        private readonly DbContext db;

        public TransactionsTransactor(DbContext context) => db = context;

        public void Add(AccountsTransactions obj) => db.Add(obj);

        public void Delete(AccountsTransactions obj) => db.Entry(obj).State = EntityState.Deleted;

        public void Edit(AccountsTransactions obj) => db.Entry(obj).State = EntityState.Modified;

        public Task<AccountsTransactions> Find<P>(P id) => Task.Run(async () => await db.FindAsync<AccountsTransactions>(id));

        public Task<IEnumerable<AccountsTransactions>> List(byte num, byte off) => Task.Run<IEnumerable<AccountsTransactions>>(async () => await db.Set<AccountsTransactions>().OrderBy(x => x.TransactionDate).Skip(off).Take(num).ToListAsync());

        public Task Save() => Task.Run(async () => await db.SaveChangesAsync());

        public Task<IEnumerable<AccountsTransactions>> Search(string qry) => Task.Run<IEnumerable<AccountsTransactions>>(async () => await db.Set<AccountsTransactions>().Where(x => EF.Functions.Like(x.TransactionDate.ToLongDateString(), $"%{qry}%")).ToListAsync());

        public bool Exists(string name) => Task.Run(async () => await Find(name)) == null;
    }
}
