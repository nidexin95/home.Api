using System;
using System.Collections.Generic;
using System.Text;
using Domain.WK_Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFrameWorkCore.SQLServer
{
    public class WkBillContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Disburse> Disburses { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<BillType> BillTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillType>().HasData(new BillType
            {
                Id = Guid.Parse("44de7e05-da1f-d17e-7ae7-7999c7f3e004"),
                UserId = Guid.Parse("dfc004e1-24a2-ef56-4d1a-463a4040900f"),
                Name = "餐饮",
                IconId = "restaurant",
            }, new BillType
            {
                Id = Guid.Parse("e96a2e05-1f4e-ee8d-bc16-e64732910bc2"),
                UserId = Guid.Parse("dfc004e1-24a2-ef56-4d1a-463a4040900f"),
                Name = "日用",
                IconId = "daily-expenses",
            }, new BillType
            {
                Id = Guid.Parse("c3621be8-a9da-9f9d-81ee-c0b6889a3692"),
                UserId = Guid.Parse("dfc004e1-24a2-ef56-4d1a-463a4040900f"),
                Name = "交通",
                IconId = "traffic",
            }, new BillType
            {
                Id = Guid.Parse("eca480e0-98b4-c01f-4684-12449d0ea658"),
                UserId = Guid.Parse("dfc004e1-24a2-ef56-4d1a-463a4040900f"),
                Name = "工资",
                IconId = "wages",
            }, new BillType
            {
                Id = Guid.Parse("825559b5-fd27-4c66-a0e4-34033f7698b6"),
                UserId = Guid.Parse("dfc004e1-24a2-ef56-4d1a-463a4040900f"),
                Name = "理财",
                IconId = "conduct",
            });
        }
    }
}
