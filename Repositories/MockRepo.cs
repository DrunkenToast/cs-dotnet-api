using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cs_dotnet_api.Models;

namespace cs_dotnet_api.Repositories
{
    public class MockRepo : IRepo
    {
        List<ItemName> itemNamesList = new List<ItemName>(){
            new ItemName(){ItemNameId=1, Name="Cool item name"},
            new ItemName(){ItemNameId=2, Name="Uncool item name"},
            new ItemName(){ItemNameId=3, Name="darn"},
        };

        List<Item> itemList = new List<Item>(){
            new Item(){ Id=1, ItemName=
            new ItemName(){ItemNameId=1, Name="Cool item name"},
            },
            new Item(){ Id=2, ItemName=
            new ItemName(){ItemNameId=2, Name="Uncool item name"},
            },
            new Item(){ Id=2, ItemName=
            new ItemName(){ItemNameId=3, Name="darn"},
            },
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

        public ItemName GetRandomItemName()
        {
            var rnd = new Random();
            var i = rnd.Next(itemNamesList.Count);
            return itemNamesList.ElementAt(i);
        }

        public void RemoveItem(Item it)
        {
            itemList.Remove(it);
        }
    }
}