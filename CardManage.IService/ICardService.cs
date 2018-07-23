using CardManage.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardManage.IService
{
    public interface ICardService
    {
        Task<IEnumerable<CardDTO>> GetAllCards();

        Task<CardDTO> GetCardById(long id);

        Task AddCard(CardDTO card);

        Task ModifyCard(CardDTO card);

        Task DelCards(long[] ids);



    }
}
