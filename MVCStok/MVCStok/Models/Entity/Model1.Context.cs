﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCStok.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MvcDbStokEntities : DbContext
    {
        public MvcDbStokEntities()
            : base("name=MvcDbStokEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TBLKATEGORI> TBLKATEGORIs { get; set; }
        public virtual DbSet<TBLMUSTERI> TBLMUSTERIs { get; set; }
        public virtual DbSet<TBLSATI> TBLSATIS { get; set; }
        public virtual DbSet<TBLURUN> TBLURUNs { get; set; }
    }
}
