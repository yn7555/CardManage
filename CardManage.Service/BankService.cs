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
    public class BankService : IBankService
    {
        public async Task<IEnumerable<BankDTO>> GetAllBanks()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                var entities =await dbContext.Bank.ToListAsync();
                return from entity in entities
                       select new BankDTO()
                       {
                           Id = entity.Id,
                           Name = entity.Name
                       };
            }
        }

        public async Task<BankDTO> GetBank(long id)
        {
            var banks = await GetAllBanks();
            return banks.Where(b => b.Id == id).SingleOrDefault();
        }
    }
}
