﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KR_SB_GK_Acad.Model.ExportColorIndex.DB
{
    using System;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities(DbConnection dbCon)
            : base(dbCon, true)
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<I_C_BuildingPart> I_C_BuildingPart { get; set; }
        public virtual DbSet<I_C_Formula> I_C_Formula { get; set; }
        public virtual DbSet<I_C_ItemGroupLong> I_C_ItemGroupLong { get; set; }
        public virtual DbSet<I_C_ItemGroupShort> I_C_ItemGroupShort { get; set; }
        public virtual DbSet<I_C_Tier> I_C_Tier { get; set; }
        public virtual DbSet<I_nn_Item_Series> I_nn_Item_Series { get; set; }
        public virtual DbSet<I_nn_Item_Tier> I_nn_Item_Tier { get; set; }
        public virtual DbSet<I_R_Item> I_R_Item { get; set; }
        public virtual DbSet<I_S_BalconyCut> I_S_BalconyCut { get; set; }
        public virtual DbSet<I_S_ItemGroup> I_S_ItemGroup { get; set; }
        public virtual DbSet<I_S_Series> I_S_Series { get; set; }
        public virtual DbSet<I_S_Side> I_S_Side { get; set; }
    }
}