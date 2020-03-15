using ExpensesapiWithAngular.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ExpensesapiWithAngular.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=ExpensesDB")
        {

        }
        public DbSet<Entry> Entries { get; set; }
    }
}