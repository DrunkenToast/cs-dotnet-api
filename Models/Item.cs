using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs_dotnet_api.Models
{
    public class Item
    {
        public int? Id {get; set;}
        public String Name {get; set;}
        public QualityType Quality {get; set;}

        static Item CreateRandom() {
            Random rnd = new Random();

            int num = rnd.Next(100);

            QualityType q = num switch {
                < 1 => QualityType.Community,
                < 2 => QualityType.Unusual,
                < 7 => QualityType.Genuine,
                < 25 => QualityType.Strange,
                < 40 => QualityType.Vintage,
                _ => QualityType.Unique,
            };

            return new Item(){
                Name = "test", // TODO: random name
                Quality = q,
            };
        }
    }
}