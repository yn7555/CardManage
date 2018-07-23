using CardManage.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardManage.IService
{
    public interface ICardTypeService
    {
        Task<IEnumerable<CardTypeDTO>> GetAllCardTypes();

        Task<CardTypeDTO> GetCardType(long id);
    }
}
