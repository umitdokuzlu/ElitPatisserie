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
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Product entity)
        {
            await _productRepository.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _productRepository.AnyAsync(x => x.Id == id);
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public IList<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public async Task<IList<Product>> GetAllAsync(int id)
        {
            return await _productRepository.GetAllAsync(x => x.Id == id);
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<IList<Product>> GetByCategory(string name)
        {
            return await _productRepository.GetByCategory(name);
        }

        public async Task<IList<Product>> GetByCategoryWithId(int id)
        {
            return await _productRepository.GetByCategoryWithId(id);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }
    }
}
