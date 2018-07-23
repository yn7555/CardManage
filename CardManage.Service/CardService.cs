using CardManage.DTO;
using CardManage.IService;
using CardManage.Service.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CardManage.Service.Db;
using Microsoft.EntityFrameworkCore;

namespace CardManage.Service
{
    public class CardService : ICardService
    {
        ICardTypeService cardTypeSvc=new CardTypeService();
        IBankService bankSvc=new BankService();
        IPersonService personSvc=new PersonService();
        public async Task AddCard(CardDTO card)
        {
            var person = await personSvc.GetPerson(card.OwnnerPersonId);
            var bank = await bankSvc.GetBank(card.OwnnerBankId);
            var cardType = await cardTypeSvc.GetCardType(card.TypeId);

            if (person == null)
            {
                throw new Exception("持卡人信息不存在");
            }
            if (bank == null)
            {
                throw new Exception("卡所属银行信息不存在");
            }
            if (cardType == null)
            {
                throw new Exception("卡类型信息不存在");
            }
            
            var entity = new CardModel()
            {
                CardNo = card.CardNo,
                CardTypeId= cardType.Id,
                OwnnerPersonId = person.Id,
                OwnnerBankId= bank.Id,
                AvaliableBalance=card.AvaliableBalance,
                Billing=card.Billing,
                NoBill=card.NoBill,
                UsefulLife=card.UsefulLife,
                BillDay=card.BillDay,
                RepayDay=card.RepayDay,
                BackNum=card.BackNum
            };
            using (MyDbContext dbContext = new MyDbContext())
            {
                var exsit =await dbContext.Card.Where(c => c.CardNo == entity.CardNo).LongCountAsync()>0;
                if (exsit)
                {
                    throw new Exception($"卡号为{entity.CardNo}的卡已存在");
                }
                
                dbContext.Card.Add(entity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DelCards(long[] ids)
        {
            var entities = from id in ids
                           select new CardModel() { Id=id};
            using (MyDbContext dbContext = new MyDbContext())
            {
                dbContext.Card.RemoveRange(entities);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CardDTO>> GetAllCards()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                var entities =await dbContext.Card.Include(c=>c.OwnnerBank).Include(c=>c.OwnnerPerson).Include(c=>c.CardType).ToListAsync();
                return from entity in entities
                       select new CardDTO()
                       {
                           Id = entity.Id,
                           TypeId = entity.CardType.Id,
                           TypeName = entity.CardType.Name,
                           OwnnerBankId = entity.OwnnerBank.Id,
                           OwnnerBankName = entity.OwnnerBank.Name,
                           OwnnerPersonId = entity.OwnnerPerson.Id,
                           OwnnerPersonName = entity.OwnnerPerson.Name,
                           CardNo = entity.CardNo,
                           AvaliableBalance=entity.AvaliableBalance,
                           Billing=entity.Billing,
                           NoBill=entity.NoBill,
                           UsefulLife=entity.UsefulLife,
                           BillDay=entity.BillDay,
                           RepayDay=entity.RepayDay,
                           BackNum=entity.BackNum
                       };
            }
        }

        public async Task<CardDTO> GetCardById(long id)
        {
            var cards =await this.GetAllCards();
            return cards.Where(c=>c.Id==id).SingleOrDefault();
        }

        public async Task ModifyCard(CardDTO card)
        {
            //暂不考虑并发
            var person = await personSvc.GetPerson(card.OwnnerPersonId);
            var bank = await bankSvc.GetBank(card.OwnnerBankId);
            var cardType = await cardTypeSvc.GetCardType(card.TypeId);

            if (person == null)
            {
                throw new Exception("持卡人信息不存在");
            }
            if (bank == null)
            {
                throw new Exception("卡所属银行信息不存在");
            }
            if (cardType == null)
            {
                throw new Exception("卡类型信息不存在");
            }

            var entity = new CardModel()
            {
                Id=card.Id,
                CardNo = card.CardNo,
                CardTypeId = cardType.Id,
                OwnnerPersonId = person.Id,
                OwnnerBankId = bank.Id,
                AvaliableBalance = card.AvaliableBalance,
                Billing = card.Billing,
                NoBill = card.NoBill,
                UsefulLife = card.UsefulLife,
                BillDay = card.BillDay,
                RepayDay = card.RepayDay,
                BackNum = card.BackNum
            };
            using (MyDbContext dbContext = new MyDbContext())
            {
                dbContext.Card.Attach(entity);
                dbContext.Entry(entity).State = EntityState.Unchanged;
                dbContext.Entry(entity).Property(e => e.CardTypeId).IsModified=true;
                dbContext.Entry(entity).Property(e => e.OwnnerBankId).IsModified = true;
                dbContext.Entry(entity).Property(e => e.OwnnerPersonId).IsModified = true;
                dbContext.Entry(entity).Property(e => e.AvaliableBalance).IsModified = true;
                dbContext.Entry(entity).Property(e => e.Billing).IsModified = true;
                dbContext.Entry(entity).Property(e => e.NoBill).IsModified = true;
                dbContext.Entry(entity).Property(e => e.UsefulLife).IsModified = true;
                dbContext.Entry(entity).Property(e => e.BillDay).IsModified = true;
                dbContext.Entry(entity).Property(e => e.RepayDay).IsModified = true;
                dbContext.Entry(entity).Property(e => e.BackNum).IsModified = true;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
