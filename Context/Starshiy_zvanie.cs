//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Военный_округ_Final_.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Starshiy_zvanie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Starshiy_zvanie()
        {
            this.Starshiy_sostav = new HashSet<Starshiy_sostav>();
        }
    
        public int id { get; set; }
        public string zvanie { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Starshiy_sostav> Starshiy_sostav { get; set; }
    }
}