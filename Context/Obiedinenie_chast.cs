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
    
    public partial class Obiedinenie_chast
    {
        public int id { get; set; }
        public Nullable<int> obiedinenie { get; set; }
        public Nullable<int> chast { get; set; }
    
        public virtual Obiedinenie Obiedinenie1 { get; set; }
        public virtual Podrazdelenie Podrazdelenie { get; set; }
    }
}