using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cs_dotnet_api.Models;

namespace cs_dotnet_api.Repositories
{
    public class MockRepo : IRepo
    {
        List<Item> itemList = new List<Item>(){
            new Item(){Id=1, Name="test"},
            new Item(){Id=2, Name="test"},
            new Item(){Id=3, Name="test"},
        };

        public void AddItem(Item it)
        {
            itemList.Add(it);
        }

        public IEnumerable<Item> GetAllItems()
        {
            return itemList;
        }


        public Item? GetItemById(int id)
        {
            return itemList.FirstOrDefault(it => it.Id == id);
        }

        public void RemoveItem(Item it)
        {
            itemList.Remove(it);
        }
    }
}