﻿namespace ExpensesapiWithAngular.Migrations
{
    using ExpensesapiWithAngular.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExpensesapiWithAngular.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExpensesapiWithAngular.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Entries.Add(new Entry() { Description = "rakin", IsExpense = false, Value = 10.11 });
        }
    }
}
