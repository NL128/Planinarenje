﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBLibrary
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PlaninarenjeEntities1 : DbContext
    {
        public PlaninarenjeEntities1()
            : base("name=PlaninarenjeEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Aktivnosti_Tbl> Aktivnosti_Tbl { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<Country_Tbl> Country_Tbl { get; set; }
        public virtual DbSet<Events_Tbl> Events_Tbl { get; set; }
        public virtual DbSet<Hotel_Tbl> Hotel_Tbl { get; set; }
        public virtual DbSet<NivoTure_Tbl> NivoTure_Tbl { get; set; }
        public virtual DbSet<Ocena_Profila_Tbl> Ocena_Profila_Tbl { get; set; }
        public virtual DbSet<Restoran_Tbl> Restoran_Tbl { get; set; }
        public virtual DbSet<Sponzori_Tbl> Sponzori_Tbl { get; set; }
        public virtual DbSet<Stanje_Tbl> Stanje_Tbl { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tip_Sponzora_Tbl> Tip_Sponzora_Tbl { get; set; }
        public virtual DbSet<Drustva_Tbl> Drustva_Tbl { get; set; }
        public virtual DbSet<Places_Tbl> Places_Tbl { get; set; }
        public virtual DbSet<AktivnostiPlaces_Tbl> AktivnostiPlaces_Tbl { get; set; }
        public virtual DbSet<AktivnostiEvents_Tbl> AktivnostiEvents_Tbl { get; set; }
        public virtual DbSet<DrustvoVodic_Tbl> DrustvoVodic_Tbl { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<DrustvaProfile_Tbl> DrustvaProfile_Tbl { get; set; }
        public virtual DbSet<Profil_Tbl> Profil_Tbl { get; set; }
        public virtual DbSet<AktivnostiProfiles_Tbl> AktivnostiProfiles_Tbl { get; set; }
        public virtual DbSet<ComentPlaces_Tbl> ComentPlaces_Tbl { get; set; }
        public virtual DbSet<PlacesOcena_Tbl> PlacesOcena_Tbl { get; set; }
        public virtual DbSet<EventOcena_Tbl> EventOcena_Tbl { get; set; }
        public virtual DbSet<EventComment_tbl> EventComment_tbl { get; set; }
    }
}
