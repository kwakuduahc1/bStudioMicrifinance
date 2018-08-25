using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using BSSL.DomainModels;
using BSSL.ObjectModels;
using System.Collections.Generic;
using System.Linq;

namespace BSSLTests
{
    public class AccountsTests
    {
        readonly DbContextOptions<AppDbConext> dbContextOptions;
        AccountsTransactor transactor;
        Guid guid = Guid.NewGuid();
        readonly Accounts accounts;
        public AccountsTests()
        {
            dbContextOptions = new DbContextOptions<AppDbConext>();
            transactor = new AccountsTransactor(new AppDbConext(dbContextOptions));
            accounts = new Accounts
            {
                AccountNumber = "1234567",
                AccountsID = guid,
                AccountTypesID = Guid.NewGuid(),
                CustomerID = Guid.NewGuid(),
                DateCreated = DateTime.Now
            };
            transactor.Add(accounts);
            transactor.Save();
        }

        [Fact]
        public async void AddTest()
        {
            var list = await transactor.List(10, 0);
            Assert.NotEmpty(list);
        }

        [Fact]
        public async void FindTest()
        {
            Accounts acc = await transactor.Find(guid);
            Assert.IsType<Accounts>(acc);
        }

        [Fact]
        public async void FindEqualityTest()
        {
            Accounts acc = await transactor.Find(guid);
            Assert.Equal(acc, accounts);
        }

        [Fact]
        public async void SearchTest()
        {
            var acc = await transactor.Search("456");
            Assert.IsAssignableFrom<IEnumerable<Accounts>>(acc);
        }

        [Fact]
        public async void DeleteTest()
        {
            var elems = await transactor.List(50, 0);
            Accounts acc = await transactor.Find(guid);
            transactor.Delete(acc);
            await transactor.Save();
            var _elems = await transactor.List(50, 0);
            Assert.True((elems.Count() - 1) == _elems.Count());
            Assert.IsType<Accounts>(acc);
        }

        [Fact]
        public async void EditTest()
        {
            Accounts acc = await transactor.Find(guid);
            acc.AccountNumber = "999999";
            transactor.Edit(acc);
            await transactor.Save();
            Assert.True(acc.AccountNumber == "999999");
        }

        [Fact]
        public void ExistsTest()
        {
            var state = transactor.Exists("78");
            Assert.False(state);
        }
    }
}
