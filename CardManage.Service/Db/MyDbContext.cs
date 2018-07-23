using CardManage.Service.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardManage.Service.Db
{
    class MyDbContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=MS-20180526MUHN;;Integrated Security=True;Initial Catalog=CardManage");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var cardBuilder= modelBuilder.Entity<CardModel>();
            cardBuilder.ToTable("T_Cards");
            cardBuilder.Property(c => c.OwnnerBankId).HasColumnName("OwnnerBank");
            cardBuilder.Property(c => c.OwnnerPersonId).HasColumnName("OwnnerPerson");
            cardBuilder.Property(c => c.CardTypeId).HasColumnName("Type");
            cardBuilder.HasOne(c => c.OwnnerBank).WithMany().HasForeignKey(c => c.OwnnerBankId);
            cardBuilder.HasOne(c => c.OwnnerPerson).WithMany().HasForeignKey(c => c.OwnnerPersonId);

            var cardTypeBuilder = modelBuilder.Entity<CardTypeModel>();
            cardTypeBuilder.ToTable("T_CardTypes");

            var bankBuilder = modelBuilder.Entity<BankModel>();
            bankBuilder.ToTable("T_Banks");

            var personBuilder = modelBuilder.Entity<PersonModel>();
            personBuilder.ToTable("T_Persons");
        }

        public DbSet<CardModel> Card { get; set; }
        public DbSet<CardTypeModel> CardType { get; set; }
        public DbSet<PersonModel> Person { get; set; }
        public DbSet<BankModel> Bank { get; set; }
    }
}
