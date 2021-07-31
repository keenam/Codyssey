using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codyssey.Identity
{
    /// <summary>
    /// Provides identity for the context.
    /// </summary>
    public class ContextIdentity
    {
        private readonly string context;
        private readonly ContextIdentityProvider provider;

        public ContextIdentity(string context, ContextIdentityProvider provider)
        {
            if (string.IsNullOrEmpty(context))
            {
                throw new ArgumentException("Invalid context.", nameof(context));
            }

            this.context = context;
            this.provider = provider;
        }

        public async Task<long> GetNextIDAsync()
        {
            var id =  await this.provider.GetNextIDAsync(this.context).ConfigureAwait(false);
            return id.First();
        }

        public async Task<IEnumerable<long>> GetNextIDAsync(int count)
        {
            return await this.provider.GetNextIDAsync(this.context, count).ConfigureAwait(false);
        }
    }
}
