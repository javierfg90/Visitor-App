using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RentApartment.Models
{
    public class VisitorContext : DbContext
    {
        public VisitorContext(DbContextOptions<VisitorContext> options)
            : base(options)
        {
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
