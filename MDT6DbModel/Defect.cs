//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MDT6DbModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Defect
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Defect()
        {
            this.Tubes = new HashSet<Tube>();
        }
    
        public int id_defects { get; set; }
        public System.DateTime dCreatedDate { get; set; }
        public Nullable<short> num_defects { get; set; }
        public byte[] defects { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tube> Tubes { get; set; }
    }
}
