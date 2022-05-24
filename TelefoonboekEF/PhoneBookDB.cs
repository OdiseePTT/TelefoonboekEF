using System.Data.Entity;
using Telefoonboek.Migrations;

namespace Telefoonboek
{
    internal class PhoneBookDB : DbContext
    {
        public PhoneBookDB() : base("phonebook") // phonebook is de naam die we aan de connectionstring gaven.
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhoneBookDB, Configuration>());
        }

        public virtual DbSet<PhoneBookItem> Items { get; set; }
    }
}
