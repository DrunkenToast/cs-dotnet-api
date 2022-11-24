using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cs_dotnet_api.Models;

namespace cs_dotnet_api.dto
{
    public class ItemReadDto
    {
        public int Id {get; set;}
        public String Name {get; set;}
        public QualityType Quality {get; set;}
    }
}