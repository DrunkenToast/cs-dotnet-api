using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cs_dotnet_api.Contexts;
using cs_dotnet_api.Models;

namespace cs_dotnet_api.Repositories
{
    public class MySqlRepo : IRepo
    {
        private readonly ItemContext _context;

        public MySqlRepo(ItemContext context) {
            _context = context;
        }

        public void AddItem(Item it)
        {
            _context.Items.Add(it);
            _save();
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items;
        }


        public Item? GetItemById(int id)
        {
            return _context.Items.FirstOrDefault(it => it.Id == id);
        }

        public void RemoveItem(Item it)
        {
            _context.Items.Remove(it);
            _save();
        }

        private void _save()
        {
            _context.SaveChanges();
        }
    }
}