using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.Extensions.Configuration;

namespace Api.Context
{
    public class BusinessContext : DbContext
    {
        public DbSet<Business> Businesses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var value = Environment.GetEnvironmentVariable("ConnectionStringAzureSQL");
            optionsBuilder.UseSqlServer(value);

        }
    }
}
