using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Samples
{
    internal static class CustomExtensions
    {
        public static async Task Transactional(this DatabaseFacade database, Func<Task> action)
        {
            IDbContextTransaction transaction = await database.BeginTransactionAsync(IsolationLevel.ReadUncommitted);
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
