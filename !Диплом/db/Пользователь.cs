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
    
    public partial class Пользователь
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Пользователь()
        {
            this.ПутевойЛист = new HashSet<ПутевойЛист>();
        }
    
        public int UserID { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public System.DateTime ДатаРождения { get; set; }
        public string Пол { get; set; }
        public int Роль { get; set; }
        public long НомерТелефона { get; set; }
        public int НомерПаспорта { get; set; }
        public int СерияПаспорта { get; set; }
        public Nullable<int> НомерЛицензии { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ПутевойЛист> ПутевойЛист { get; set; }
    }
}
