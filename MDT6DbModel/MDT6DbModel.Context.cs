﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MDT6DBEntities : DbContext
    {
        public MDT6DBEntities()
            : base("name=MDT6DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Defect> Defects { get; set; }
        public virtual DbSet<Melt> Melts { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Standart> Standarts { get; set; }
        public virtual DbSet<Tube> Tubes { get; set; }
        public virtual DbSet<Typesize> Typesizes { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}