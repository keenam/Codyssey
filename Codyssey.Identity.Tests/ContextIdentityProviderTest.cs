using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Codyssey.Identity.Tests
{
    public class ContextIdentityProviderTest
    {
        private readonly DbContextOptions<IdentityDbContext> sqliteOptions;

        public ContextIdentityProviderTest()
        {
            sqliteOptions = new DbContextOptionsBuilder<IdentityDbContext>()
                .UseSqlite(@"Data source=.\test.db")
                .Options;
        }

        [Fact]
        public async void TestGetNextIDAsync()
        {
            var cip = new ContextIdentityProvider(this.sqliteOptions);
            
            const string mainContext = "main";
            var nextIDList = await cip.GetNextIDAsync(mainContext).ConfigureAwait(false);
            Assert.Single(nextIDList);
            var firstID = nextIDList.Single();
            nextIDList = await cip.GetNextIDAsync(mainContext).ConfigureAwait(false);
            Assert.Single(nextIDList);
            var nextID = nextIDList.Single();

            Assert.True(firstID < nextID);
        }

        [Fact]
        public async void TestGetMultipleIDs()
        {
            var cip = new ContextIdentityProvider(this.sqliteOptions);

            const string idContext = "secondary";
            var count = 10;
            var nextIDList = await cip.GetNextIDAsync(idContext, count).ConfigureAwait(false);

            Assert.True(nextIDList.Count() == count);
            
            // test increment order
            long? prev = null;
            foreach (var value in nextIDList)
            {
                if (prev.HasValue)
                {
                    Assert.True(prev < value);
                }

                prev = value;
            }
        }
    }
}
