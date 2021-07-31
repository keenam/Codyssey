using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Codyssey.Identity
{
    /// <summary>
    /// Identity Provider with Entity Framework
    /// </summary>
    public class ContextIdentityProvider
    {
        private readonly DbContextOptions options;

        public ContextIdentityProvider(DbContextOptions options)
        {
            this.options = options;
        }

        public async Task<IEnumerable<long>> GetNextIDAsync(string context, int count = 1)
        {
            if (count <= 0)
            {
                throw new ArgumentException("must be greater than 0", nameof(count));
            }

            var lastID = 0L;
            await this.EnsureRecordAsync(context);
            using (var dbContext = new IdentityDbContext(this.options))
            using (var dbTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var retryCount = 5;
                    do
                    {
                        var record = dbContext.Identity.SingleOrDefault(record => record.Context == context);
                        record.NextID += count;
                        var result = await dbContext.SaveChangesAsync();
                        if (result == 1)
                        {
                            dbTransaction.Commit();
                            lastID = record.NextID;

                            break;
                        }
                    } while (--retryCount > 0);
                }
                catch
                {
                    dbTransaction.Rollback();
                }
            }

            var next = new long[count];
            for (int start = 0; start < count; ++start)
            {
                next[next.Length - start - 1] = lastID - start;
            }

            return next;
        }

        private async Task EnsureRecordAsync(string context)
        {
            using IdentityDbContext dbContext = new IdentityDbContext(this.options);
            var retryCount = 5;
            do
            {
                var record = dbContext.Identity.SingleOrDefault(record => record.Context == context);
                if (record == null)
                {
                    var identityID = 1L;
                    if (dbContext.Identity.Any())
                    {
                        identityID = dbContext.Identity.Max(record => record.ID) + 1;
                    }
                    record = new Identity
                    {
                        ID = identityID,
                        Context = context,
                        NextID = 0
                    };
                    await dbContext.AddAsync(record);
                    var result = await dbContext.SaveChangesAsync();
                    if (result == 1)
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            } while (--retryCount > 0);

            throw new Exception($"Failed to fetch the record for the {context}");
        }
    }
}
