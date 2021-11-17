using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCrud.Models
{
    public class ProductContext:DbContext
    {

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<productMaster> productMaster { get; set; }

        public DbSet<catMaster> catMaster { get; set; }
    }
}
