using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Военный_округ_Final_.Dao.Entities
{
    class BoevayaTehnika : Dao.Entities.Entity
    {
        public int id{get; set;}
        public int podrazdelenieId{get; set;}
        public string tipBoevoyTehniki{get; set;}
        public int kolichestvo{get; set;}
        public string dopInfo{get; set;}
        
    }
}
