//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace benim_kütüphanem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class benimkutuphanemDBEntities1 : DbContext
    {
        public benimkutuphanemDBEntities1()
            : base("name=benimkutuphanemDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<adminBilgi> adminBilgi { get; set; }
        public virtual DbSet<kategoriBilgi> kategoriBilgi { get; set; }
        public virtual DbSet<kitapBilgi> kitapBilgi { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<üyeBilgi> üyeBilgi { get; set; }
        public virtual DbSet<üyeKitapBilgi> üyeKitapBilgi { get; set; }
    }
}
