//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _Диплом.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Продукт
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Продукт()
        {
            this.ПутевойЛист = new HashSet<ПутевойЛист>();
        }
    
        public int ProductID { get; set; }
        public string Название { get; set; }
        public string Производитель { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ПутевойЛист> ПутевойЛист { get; set; }
    }
}
