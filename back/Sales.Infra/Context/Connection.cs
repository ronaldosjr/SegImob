using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Internal;

namespace Sales.Infra.Context
{
    public class Connection : IConnection
    {
        private readonly DbContext _context;

        public Connection(SalesContext context)
        {
            _context = context;
            CheckIfMigrationIsRequired(context);
        }

        public DbContext Context() => _context;

        public void Commit() =>_context.SaveChanges();

        private void CheckIfMigrationIsRequired(SalesContext context)
        {
            if (context.Options != null)
            {
                if (context.Options.Extensions.OfType<InMemoryOptionsExtension>().Any())
                {
                    return;
                }
            }
           if (_context.Database.GetPendingMigrations().Any())
                _context.Database.Migrate();
        }

        
    }
}

