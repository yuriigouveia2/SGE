using Microsoft.EntityFrameworkCore;
using SGE.DataAccess.Entities;
using SGE.DataAccess.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SGE.Repository.Context
{
    public class SgeContext : DbContext
    {
        #region DbSets
        public DbSet<Address> Addresses { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion

        public SgeContext(DbContextOptions<SgeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(fk => fk.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
