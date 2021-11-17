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
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
    }
}
