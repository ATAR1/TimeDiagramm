//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JournalDbModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class JournalRecord
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Shift { get; set; }
        public string Work { get; set; }
        public System.TimeSpan Start { get; set; }
        public System.TimeSpan End { get; set; }
        public string Employee { get; set; }
        public string Description { get; set; }
        public string WorkArea { get; set; }
        public string DefectoscopeName { get; set; }
    
        public virtual Operation Operation { get; set; }
    }
}
