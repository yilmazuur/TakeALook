using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace TakeALook.Repository.Migrations
{

    /// <summary>
    /// Package Manager Console:  Enable-Migrations �EnableAutomaticMigrations -Force -Verbose
    /// Update-Database -Verbose -ConnectionStringName "TakeALookEntities" komutu i�in olu�an tablolar� elle silip tekrar olu�turmak istedi�imizde
    /// MigrationHistory tablosudan da komut ge�mi�ini silmeliyiz.
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
