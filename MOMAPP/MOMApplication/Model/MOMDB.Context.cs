﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MOMApplication.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MOMEntities : DbContext
    {
        public MOMEntities()
            : base("name=MOMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tblMom> tblMoms { get; set; }
        public DbSet<tblProjectInfo> tblProjectInfoes { get; set; }
        public DbSet<tblRole> tblRoles { get; set; }
        public DbSet<tblUserInfo> tblUserInfoes { get; set; }
    }
}
