using CardManage.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardManage.IService
{
    public interface IBankService
    {
        Task<IEnumerable<BankDTO>> GetAllBanks();

        Task<BankDTO> GetBank(long id);
    }
}
