using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace TakeALook.Repository.Migrations
{

    /// <summary>
    /// Package Manager Console:  Enable-Migrations –EnableAutomaticMigrations -Force -Verbose
    /// Update-Database -Verbose -ConnectionStringName "TakeALookEntities" komutu için oluþan tablolarý elle silip tekrar oluþturmak istediðimizde
    /// MigrationHistory tablosudan da komut geçmiþini silmeliyiz.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<TakeALookDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TakeALookDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
