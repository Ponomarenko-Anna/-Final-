using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Военный_округ_Final_.Dao.Entities
{
    class Sluzhaschiy : Dao.Entities.Entity
    {
        public int id { get; set; }
        public string imya { get; set; }
        public string otchestvo { get; set; }
        public string familiya { get; set; }
        public int idStarshego { get; set; }
        public string zvanie { get; set; }
        public List<string> specialnost { get; set; }
        
    }
}
