using Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public class VendingDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
       
        public DbSet<Business.ContainableItem> ContainbleItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-FTFFKM6\SQLEXPRESS;Database=VendingDb;Trusted_Connection=True;");
        }

    }
}
