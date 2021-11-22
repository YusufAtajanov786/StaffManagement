using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RepoContext :DbContext
    {
        public RepoContext(DbContextOptions<RepoContext> options)
            :base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Warehouse>()
                .HasOne(u => u.User)
                .WithMany(w => w.User_Warehouses)
                .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<User_Warehouse>()
                .HasOne(w => w.Warehouse)
                .WithMany(w => w.User_Warehouses)
                .HasForeignKey(w => w.WarehouseId);
                      
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }

        public DbSet<InputFactura> InputFacturas { get; set; }
    }
}
