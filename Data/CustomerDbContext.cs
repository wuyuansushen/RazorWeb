using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorWeb.Models;

namespace RazorWeb.Data
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext(DbContextOptions dboptions):base(dboptions)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
