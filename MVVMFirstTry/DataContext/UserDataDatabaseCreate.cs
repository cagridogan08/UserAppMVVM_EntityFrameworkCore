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
            //options.UseSqlServer("workstation id=default.mssql.somee.com;packet size=4096;user id=cagridogan08_SQLLogin_1;pwd=p5mcsnzrt3;data source=default.mssql.somee.com;persist security info=False;initial catalog=default");
            return new UserDataContext(options.Options);
        }
    }
}
