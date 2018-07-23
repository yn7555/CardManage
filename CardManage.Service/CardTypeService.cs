using CardManage.DTO;
using CardManage.IService;
using CardManage.Service.Db;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CardManage.Service
{
    public class CardTypeService : ICardTypeService
    {
        public async Task<IEnumerable<CardTypeDTO>> GetAllCardTypes()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                var entities=await dbContext.CardType.ToListAsync();
                return from entity in entities
                       select new CardTypeDTO()
                       {
                           Id=entity.Id,
                           Name=entity.Name
                       };
            }
        }

        public async Task<CardTypeDTO> GetCardType(long id)
        {
            var types = await GetAllCardTypes();
            return types.Where(b => b.Id == id).SingleOrDefault();
        }
    }
}
