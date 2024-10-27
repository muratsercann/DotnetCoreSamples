using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace WinFormsApp1
{
    public static class MyExtenstions
    {
        public static async Task Transactional(this DatabaseFacade database, Func<Task> action, System.Data.IsolationLevel isolationLevel = System.Data.IsolationLevel.ReadUncommitted)
        {
            Console.WriteLine("isolation level : " + isolationLevel.ToString());
            var currentTransaction = database.CurrentTransaction?.TransactionId;
            IDbContextTransaction transaction = await database.BeginTransactionAsync(isolationLevel);
            try
            {
                await action();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
