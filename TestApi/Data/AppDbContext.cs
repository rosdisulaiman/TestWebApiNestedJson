using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base (option)
        {
            //Database.EnsureCreated();
        }
        public DbSet<ScanData> ScanDatas { get; set; }
        public DbSet<Face> Faces { get; set; }
    }
}
