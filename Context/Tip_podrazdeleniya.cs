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
    
    public partial class Tip_podrazdeleniya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tip_podrazdeleniya()
        {
            this.Podrazdelenie = new HashSet<Podrazdelenie>();
        }
    
        public int id { get; set; }
        public string nazvanie { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Podrazdelenie> Podrazdelenie { get; set; }
    }
}
