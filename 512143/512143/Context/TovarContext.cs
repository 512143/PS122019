using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _512143.Models;

namespace _512143.Context
{
    public class TovarContext : DbContext
    {
        public TovarContext(DbContextOptions<TovarContext> options)
    : base(options)
        {

        }
        public DbSet<Tovar> Tovars { get; set; }
    }
}
