using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BikeProject.Models;

namespace BikeProject.Data
{
    public class BikeProjectContext : DbContext
    {
        public BikeProjectContext (DbContextOptions<BikeProjectContext> options)
            : base(options)
        {
        }

        public DbSet<BikeProject.Models.Purchaser> Purchaser { get; set; }

        public DbSet<BikeProject.Models.SaleMan> SaleMan { get; set; }

        public DbSet<BikeProject.Models.Banch> Banch { get; set; }

        public DbSet<BikeProject.Models.BikeSale> BikeSale { get; set; }
    }
}
