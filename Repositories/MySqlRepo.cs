using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cs_dotnet_api.Contexts;
using cs_dotnet_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cs_dotnet_api.Repositories
{
    public class MySqlRepo : IRepo
    {
        private readonly DatabaseContext _context;
        private readonly Random _rnd = new();

        public MySqlRepo(DatabaseContext context) {
            _context = context;
        }

        public void AddItem(Item it)
        {
            _context.Items.Add(it);
            _save();
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.Include(it => it.ItemName);
        }


        public Item? GetItemById(int id)
        {
            return _context.Items.Include(it => it.ItemName).FirstOrDefault(it => it.Id == id);
        }

        public ItemName GetRandomItemName()
        {
            return _context.ItemNames.Skip(_rnd.Next(0, _context.ItemNames.Count())).First();
        }

        public void RemoveItem(Item it)
        {
            _context.Items.Remove(it);
            _save();
        }

        public Keys GetKeys()
        {
            var keys = _context.Keys.FirstOrDefault();
            if (keys == null) {keys = new Keys(){Id=1, Amount=0};}
            return keys;
        }

        public void UpdateKeys(Keys keys)
        {
            var entry = _context.Keys.First(k => k.Id == keys.Id);
            entry = keys; // TODO: check if this updates
            _save();
        }

        private void _save()
        {
            _context.SaveChanges();
        }
    }
}