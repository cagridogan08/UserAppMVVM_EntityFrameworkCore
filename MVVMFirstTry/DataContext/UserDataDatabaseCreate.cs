using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirstTry.DataContext
{
    public class UserDataDatabaseCreate : IDesignTimeDbContextFactory<UserDataContext>
    {
        public UserDataContext CreateDbContext(string[]? args =null)
        {
            var options = new DbContextOptionsBuilder<UserDataContext>();
            options.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=Cagri.dogan1");
            return new UserDataContext(options.Options);
        }
    }
}
