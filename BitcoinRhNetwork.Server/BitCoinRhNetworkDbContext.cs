using BitCoinRhNetwork.Entities.Peers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace BitCoinRhNetwork.Server
{
    public class BitCoinRhNetworkDbContext : DbContext
    {
        public DbSet<Peer> Peers { get; set; }

        /// <summary>
        /// Whether the database has been initialized.
        /// </summary>
        public static bool DatabaseIsInitialized { get; private set; }

        public void Initialize()
        {
            if (!DatabaseIsInitialized)
            {
                // Initialize the database and migrate it to the latest version.
                Database.SetInitializer(
                    new MigrateDatabaseToLatestVersion<BitCoinRhNetworkDbContext, BitCoinRhNetworkDbMigrationsConfiguration>());
                Database.Initialize(true);

                DatabaseIsInitialized = true;
            }
        }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            // Prevents from unwanted or accidental cascade deletes. Soft-delete is used mostly anyway.
            mb.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Peer.
            mb.Entity<Peer>().Property(u => u.City).HasMaxLength(50);
            mb.Entity<Peer>().Property(u => u.ContinentName).HasMaxLength(30);
            mb.Entity<Peer>().Property(u => u.CountryName).HasMaxLength(30);
            mb.Entity<Peer>().Property(u => u.Ip).HasMaxLength(20);
            mb.Entity<Peer>().Property(u => u.Latitude).HasMaxLength(30);
            mb.Entity<Peer>().Property(u => u.Longitude).HasMaxLength(30);
            mb.Entity<Peer>().Property(u => u.Zip).HasMaxLength(20);
            mb.Entity<Peer>().Property(u => u.Type).HasMaxLength(10);
        }
    }

    internal class BitCoinRhNetworkDbMigrationsConfiguration : DbMigrationsConfiguration<BitCoinRhNetworkDbContext>
    {
        public BitCoinRhNetworkDbMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BitCoinRhNetworkDbContext context)
        {
            base.Seed(context);
        }
    }
}
