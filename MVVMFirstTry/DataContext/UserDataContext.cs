using MVVMFirstTry.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MVVMFirstTry.DataContext
{
    public class UserDataContext : DbContext
    {
        public UserDataContext(DbContextOptions options) : base(options) { }

        public UserDataContext()
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=Cagri.dogan1");
        }
        public int GetSequenceValue()
        {
            var connection = Database.GetDbConnection();
            connection.Open();
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT MAX(\"Id\") FROM public.\"Users\"";
                var obj = cmd.ExecuteScalar();
                int anInt = (int)obj;
                connection.Close();
                return anInt;
            }
        }
    }
} 
