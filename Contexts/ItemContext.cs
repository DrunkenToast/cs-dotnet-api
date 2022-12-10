using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cs_dotnet_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cs_dotnet_api.Contexts
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items {get; set;}
        public DbSet<ItemName> ItemNames {get; set;}

        public ItemContext(DbContextOptions<ItemContext> opt) : base(opt) {
        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            List<ItemName> itemNames = new();
            foreach (var it in names.Select((value, index) => new {value, index})) {
                itemNames.Add(
                    new ItemName() {
                        ItemNameId=it.index+1,
                        Name=it.value,
                    }
                );
            }
            
            modelBuilder.Entity<ItemName>().HasData(itemNames);
        }
        #endregion

        private static List<string> names = new List<string>() {
            "Leaf Lover's Special",
            "Oily Oef",
            "Glyphid Slammer",

            "Pots O' Gold",
            "Dark Morkite",
            "Red Rock Blaster",

            "Sandvich",
            "Medigun",
            "Jarate",
            "Force-A-Nature",
            "Dead Ringer",
            "Cow Mangler 5000",
            "Righteous Bison",
            "Eyelander",
            "Frying Pan",
            "Rocket Launcher",
            "Rocket Jumper",
            "Market Gardener",
            "Scattergun",
            "Minigun",
            "Second Banana",

            "Gibus",
            "Archimedes",
            "Camera beard",
            "Troublemakers tossle cap",
            "Tyrants helm",
            "The Danger",
            "Team Captain",
            "War pig",
            "Exquisite Rack",
            "Dead of Night",
            "Pyromancer's Mask",
        };
    }
}