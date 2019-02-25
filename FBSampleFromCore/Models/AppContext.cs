using System;
using System.Collections.Generic;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.EntityFrameworkCore.Firebird.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FBSampleFromCore.Models
{
    class AppContext : DbContext
    {
        private readonly String _connString;
        public DbSet<User> Users { get; set; }

        public AppContext(String connString)
        {
            _connString = connString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseFirebird(_connString);
        }


    }
}
