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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task AddAsync(Category entity)
        {
            await _categoryRepository.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _categoryRepository.AnyAsync(x => x.Id == id);
        }

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public IList<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public async Task<IList<Category>> GetAllAsync(int id)
        {
            return await _categoryRepository.GetAllAsync(x => x.Id == id);
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }
    }
}
