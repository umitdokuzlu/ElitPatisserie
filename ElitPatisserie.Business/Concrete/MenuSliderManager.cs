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
    public class MenuSliderManager : IMenuSliderService
    {
        private readonly IMenuSliderRepository _menuSliderRepository;

        public MenuSliderManager(IMenuSliderRepository menuSliderRepository)
        {
            _menuSliderRepository = menuSliderRepository;
        }

        public async Task AddAsync(MenuSlider entity)
        {
            await _menuSliderRepository.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _menuSliderRepository.AnyAsync(x => x.Id == id);
        }

        public void Delete(MenuSlider entity)
        {
            _menuSliderRepository.Delete(entity);
        }

        public async Task<IList<MenuSlider>> GetAllAsync(int id)
        {
            return await _menuSliderRepository.GetAllAsync(x => x.Id == id);
        }

        public async Task<IList<MenuSlider>> GetAllAsync()
        {
            return await _menuSliderRepository.GetAllAsync();
        }

        public async Task<MenuSlider> GetByIdAsync(int id)
        {
            return await _menuSliderRepository.GetByIdAsync(id);
        }

        public void Update(MenuSlider entity)
        {
            _menuSliderRepository.Update(entity);
        }
    }
}
