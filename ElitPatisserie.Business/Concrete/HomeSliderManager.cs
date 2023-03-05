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
    public class HomeSliderManager : IHomeSliderService
    {
        private readonly IHomeSliderRepository _homeSliderRepository;

        public HomeSliderManager(IHomeSliderRepository homeSliderRepository)
        {
            _homeSliderRepository = homeSliderRepository;
        }

        public async Task AddAsync(HomeSlider entity)
        {
            await _homeSliderRepository.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _homeSliderRepository.AnyAsync(x => x.Id == id);
        }

        public void Delete(HomeSlider entity)
        {
            _homeSliderRepository.Delete(entity);
        }

        public async Task<IList<HomeSlider>> GetAllAsync(int id)
        {
            return await _homeSliderRepository.GetAllAsync(x => x.Id == id);
        }

        public async Task<IList<HomeSlider>> GetAllAsync()
        {
            return await _homeSliderRepository.GetAllAsync();
        }

        public async Task<HomeSlider> GetByIdAsync(int id)
        {
            return await _homeSliderRepository.GetByIdAsync(id);
        }

        public void Update(HomeSlider entity)
        {
            _homeSliderRepository.Update(entity);
        }
    }
}
