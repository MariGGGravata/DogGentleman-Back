﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DogGentleman.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntitiesDogGentleman : DbContext
    {
        public EntitiesDogGentleman()
            : base("name=EntitiesDogGentleman")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Racao> RacaoSet { get; set; }
        public virtual DbSet<Produto> ProdutoSet { get; set; }
        public virtual DbSet<Carrinho> CarrinhoSet { get; set; }
    }
}