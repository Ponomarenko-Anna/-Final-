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
    
    public partial class Transportnaya_tehnika
    {
        public int id { get; set; }
        public Nullable<int> podrazdelenie { get; set; }
        public Nullable<int> tip { get; set; }
        public Nullable<int> kolichestvo { get; set; }
        public string dop_info { get; set; }
    
        public virtual Podrazdelenie Podrazdelenie1 { get; set; }
        public virtual Tip_transportnoy_tehniki Tip_transportnoy_tehniki { get; set; }
    }
}
