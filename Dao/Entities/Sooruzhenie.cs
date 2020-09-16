using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Военный_округ_Final_.Dao.Entities
{
    class Sooruzhenie : Dao.Entities.Entity
    {
        public int id{get; set;}
        public string nazvanie{get; set;}
        public int podrazdelenieId{get; set;}
        
    }
}
