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
    public class ChefManager : IChefService
    {
        private readonly IChefRepository _chefRepository;

        public ChefManager(IChefRepository chefRepository)
        {
            _chefRepository = chefRepository;
        }

        public async Task AddAsync(Chef entity)
        {
            await _chefRepository.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _chefRepository.AnyAsync(x => x.Id == id);
        }

        public void Delete(Chef entity)
        {
            _chefRepository.Delete(entity);
        }

        public async Task<IList<Chef>> GetAllAsync(int id)
        {
            return await _chefRepository.GetAllAsync(x => x.Id == id);
        }

        public async Task<IList<Chef>> GetAllAsync()
        {
            return await _chefRepository.GetAllAsync();
        }

        public async Task<Chef> GetByIdAsync(int id)
        {
            return await _chefRepository.GetByIdAsync(id);
        }

        public void Update(Chef entity)
        {
            _chefRepository.Update(entity);
        }
    }
}
