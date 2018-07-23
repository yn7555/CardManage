using CardManage.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardManage.Service.Db.ModelConfig
{
    //public class CardConfig:EntityTypeConfiguration<CardModel>
    //{
    //    public CardConfig()
    //    {
    //        this.ToTable("T_Cards");
    //        this.Property(p => p.OwnnerBankId).HasColumnName("OwnnerBank");
    //        this.Property(p => p.OwnnerPersonId).HasColumnName("OwnnerPerson");
    //        this.Property(p => p.CardTypeId).HasColumnName("Type");
    //        this.HasRequired(c=>c.OwnnerBank).WithMany().HasForeignKey(c=>c.OwnnerBankId);
    //        this.HasRequired(c => c.OwnnerPerson).WithMany().HasForeignKey(c => c.OwnnerPersonId);
    //    }
    //}
}
