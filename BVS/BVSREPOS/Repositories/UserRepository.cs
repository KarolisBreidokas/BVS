using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BVS.Data.DTOs;
using BVS.Data.Models;
using BVS.Data.Repositories.Interfaces;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.EntityFrameworkCore;

namespace BVS.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly BVSDBContext _context;

        public UserRepository(BVSDBContext context)
        {
            _context = context;
            _users = _context.Users;
        }

        public async Task<User> getUserInfo(int id)
        {
            var ans = await _users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (ans is null)
            {
                throw new IndexOutOfRangeException();
            }

            return ans;
        }

        public async Task updateAccountInfo(int id, NewUserDto user)
        {
            var ans = await _users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (ans is null)
            {
                throw new IndexOutOfRangeException();
            }

            ans.Email = user.Email;
            ans.Name = user.Name;
            ans.Surname = user.Surname;
            ans.Username = user.Username;
            ans.Password = BCryptHelper.HashPassword(user.Password, BCryptHelper.GenerateSalt());
            _users.Update(ans);
            await _context.SaveChangesAsync();
        }

        public async Task<int> createNewAccount(NewUserDto user)
        {
            var userEntity = new User
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Password = BCryptHelper.HashPassword(user.Password, BCryptHelper.GenerateSalt()),
                Username = user.Username
            };
            _users.Add(userEntity);
            var t=await _context.SaveChangesAsync();
            return userEntity.Id;
        }

        public async Task<bool> checkData(string username, string password)
        {
            var user = await _users.Where(x => x.Username == username).FirstOrDefaultAsync();
            if (user is null)
            {
                return false;
            }

            return BCryptHelper.CheckPassword(password, user.Password);
        }
    }
}
