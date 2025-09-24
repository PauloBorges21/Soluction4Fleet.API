using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using RT.Comb;

namespace Soluction4Fleet.API.Infrastructure.Data
{
    public class CombGuidValueGenerator : ValueGenerator<Guid>
    {
        private static readonly ICombProvider _provider = Provider.Sql;
        public override bool GeneratesTemporaryValues => false;
        public override Guid Next(EntityEntry entry)
        {
            return _provider.Create();
        }
    }
}
