﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_PR16_clothes_Balashova.ApplicationData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AlisaEntities1 : DbContext
    {
        private static AlisaEntities1 _context;
        public AlisaEntities1()
            : base("name=AlisaEntities1")
        {
        }
        public static AlisaEntities1 GetContext()
        {
            if (_context == null)
                _context = new AlisaEntities1();
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clothes> Clothes { get; set; }
        public virtual DbSet<Cvet> Cvet { get; set; }
        public virtual DbSet<Razmer> Razmer { get; set; }
        public virtual DbSet<Strana> Strana { get; set; }
    }
}