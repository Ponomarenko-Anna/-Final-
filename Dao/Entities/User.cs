using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Военный_округ_Final_.Dao.Entities
{
    class User : Dao.Entities.Entity
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string changeRights { get; set; }

    }

    
}
