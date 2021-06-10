using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApp.Models
{
    public class UserContext : DbContext
    {
        public DbSet<ConferenceUser> ConferenceUsers { get; set; }
        public DbSet<CT> ConferenceTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-CCAAP6C;Database = ConferenceUser;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")                
                .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);

        }
    }
}
