using Roomax.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Roomax.Data
{
    public class RoomaxDbContext : DbContext
    {
        public RoomaxDbContext() : base ("RoomaxDb")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Civility> Civilities { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RoomFile> RoomFiles { get; set; }
    }


}