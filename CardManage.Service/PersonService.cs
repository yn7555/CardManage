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
    public class PersonService : IPersonService
    {
        public async Task<IEnumerable<PersonDTO>> GetAllPersons()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                var entities =await dbContext.Person.ToListAsync();
                return from entity in entities
                       select new PersonDTO()
                       {
                           Id = entity.Id,
                           Name = entity.Name
                       };
            }
        }

        public async Task<PersonDTO> GetPerson(long id)
        {
            var persons = await GetAllPersons();
            return persons.Where(b => b.Id == id).SingleOrDefault();
        }
    }
}
