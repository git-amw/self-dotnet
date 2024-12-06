using MessageConsumer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageConsumer.Repo
{
    public class AddToDb : IAddToDb
    {
       /* private readonly IDbContextFactory<AppDbContext> contextFactory;
        private readonly AppDbContext dbContext;*/

        private readonly AppDbContext db;

        public AddToDb(AppDbContext db)
        {
            this.db = db;
        }

        /*public AddToDb(IDbContextFactory<AppDbContext> contextFactory, AppDbContext dbContext)
        {
            this.contextFactory = contextFactory;
            this.dbContext = contextFactory.CreateDbContext(); ;
        }*/

        public async Task<bool> SaveToDb(int number)
        {
            /*var accdetails = new AccountDetails()
            {
                AcccountNumber = number
            };
            // using AppDbContext dbContext = contextFactory.CreateDbContext();
            await dbContext.AccountTable.AddAsync(accdetails);
            await dbContext.SaveChangesAsync();
            return true;*/

            var accdetails = new AccountDetails()
            {   
                AcccountNumber = number
            };
            await db.AccountTable.AddAsync(accdetails);
            await db.SaveChangesAsync();
            return true;
        }

    }
}
