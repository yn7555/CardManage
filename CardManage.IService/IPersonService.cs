using CardManage.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardManage.IService
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDTO>> GetAllPersons();

        Task<PersonDTO> GetPerson(long id);
    }
}
