using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using cs_dotnet_api.Repositories;

namespace cs_dotnet_api.Models
{
    public class Item
    {
        public int? Id {get; set;}

        public ItemName ItemName {get; set;}

        public QualityType Quality {get; set;}
        public override string ToString()
        {
            return $"{Id}: {ItemName.Name} {ItemName.ItemNameId} {Quality}";
        }
    }
}