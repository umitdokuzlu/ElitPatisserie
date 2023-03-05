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
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddAsync(User entity)
        {
            await _userRepository.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _userRepository.AnyAsync(x=>x.Id==id);
        }

        public void Delete(User entity)
        {
            _userRepository.Delete(entity);
        }

        public async Task<IList<User>> GetAllAsync(int id)
        {
            return await _userRepository.GetAllAsync(x=>x.Id==id);
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetByUser(User user)
        {
            return await _userRepository.GetByUser(x => x.Password == user.Password);
        }

        public void Update(User entity)
        {
            _userRepository.Update(entity);
        }
    }
}
