using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cs_dotnet_api.Models;

namespace cs_dotnet_api.Repositories
{
    public interface IRepo
    {
        IEnumerable<Item> GetAllItems();
        Item? GetItemById(int id);
        void AddItem(Item it);
        void RemoveItem(Item it);

        ItemName GetRandomItemName();
    }
}