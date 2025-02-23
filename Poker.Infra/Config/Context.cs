using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Infra.Config
{
    public class Context : DbContext
    {
        private readonly IConfiguration _configuration;
        public Context(DbContextOptions<Context> options, IConfiguration configuration) 
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseInMemoryDatabase("PokerDb");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
