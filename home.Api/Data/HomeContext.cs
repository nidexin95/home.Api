using home.Api.Models.Homes;
using home.Api.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace home.Api.Data
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<HomeBase> HomeBases { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user
            modelBuilder.Entity<User>()
                        .Property(x => x.UserName)
                        .IsRequired()
                        .HasMaxLength(100);
            modelBuilder.Entity<User>()
                        .Property(x => x.Phone)
                        .IsRequired();
            modelBuilder.Entity<User>()
                        .Property(x => x.PassWord)
                        .IsRequired();
            //HomeBase
            modelBuilder.Entity<HomeBase>()
                        .Property(x => x.CommunityName)
                        .IsRequired()
                        .HasMaxLength(100);
        }
    }
}
