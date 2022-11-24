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

        public ItemContext(DbContextOptions<ItemContext> opt) : base(opt) {

        }
    }
}