using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Военный_округ_Final_.Dao.Entities
{
    class Podrazdelenie : Dao.Entities.Entity
    {
        public int id{get; set;}
        public string tipPodrazdeleniya{get; set;}
        public string nazvanie{get; set;}
        public int idStarshegoPodrazdeleniya{get; set;}
        public int komandir{get; set;}
        public string location{get; set;}
        
    }
}
