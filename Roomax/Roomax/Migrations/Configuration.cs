using Roomax.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Roomax.Migrations
{
    public class Configuration : DbMigrationsConfiguration<RoomaxDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RoomaxDbContext context)
        {
            /*context.Civilities.AddOrUpdate(
                new Models.Civility { Label = "Monsieur" },
                new Models.Civility { Label = "Madame" },
                new Models.Civility { Label = "Mademoiselle" });*/
        }
    }
}