using ElitPatisserie.Business.Abstract;
using ElitPatisserie.Data.Abstract;
using ElitPatisserie.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task AddAsync(Contact entity)
        {
            await _contactRepository.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _contactRepository.AnyAsync(x => x.Id == id);
        }

        public void Delete(Contact entity)
        {
            _contactRepository.Delete(entity);
        }

        public async Task<IList<Contact>> GetAllAsync(int id)
        {
            return await _contactRepository.GetAllAsync(x=>x.Id==id);
        }

        public async Task<IList<Contact>> GetAllAsync()
        {
            return await _contactRepository.GetAllAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _contactRepository.GetByIdAsync(id);
        }

        public void Update(Contact entity)
        {
            _contactRepository.Update(entity);
        }
    }
}
