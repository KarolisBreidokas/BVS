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
    public class ATM_Repository:IATM_Repository
    {
        private readonly DbSet<ATM> _ATMs;
        private readonly BVSDBContext _context;

        public ATM_Repository(BVSDBContext context)
        {
            _context = context;
            _ATMs = _context.ATMs;
        }

        public async Task changeATMData(int id, NewATMDto atmDto)
        {
            var ans = await _ATMs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (ans is null)
                throw new NotImplementedException();

            ans.Address = atmDto.Address;
            ans.AditionalInfo = atmDto.AditionalInfo;

            await _context.SaveChangesAsync();
        }

        public async Task<int> createNewATM(NewATMDto atmDto)
        {
            var ATMEntity = new ATM
            {
                Address = atmDto.Address,
                AditionalInfo = atmDto.AditionalInfo
            };

            await _context.SaveChangesAsync();
            return ATMEntity.Id;
        }

        public async Task<bool> delete(int id)
        {
            var ans = await _ATMs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (ans is null)
                throw new NotImplementedException();

            _ATMs.Remove(ans);

            return await _context.SaveChangesAsync() > 0;        //nzn kaip gaut boola pasalino ar ne
        }

        /// <summary>
        /// idk kas cia yra
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Exists(int id)
        {
            var ans = await _ATMs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (ans is null)
                return false;
            else
                return true;
        }

        public async Task<ATM> getATM(int id)
        {
            var ans = await _ATMs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }

        public ICollection<ATM> getATMs()
        {
            var ans = _ATMs.ToList();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }

        public ICollection<ATM> search(string address)
        {
            var ans = _ATMs.Where(x => x.Address.Contains(address)).ToList();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }

        public async Task updateATMState(int atmId, ATM_State state)
        {
            var ans = await _ATMs.Where(x => x.Id == atmId).FirstOrDefaultAsync();
            if (ans is null)
                throw new NotImplementedException();

            if (state.Equals("InTransit"))
            {
                ans.State = state;
                ans.Online = false;
            }
            else
            {
                ans.State = state;
                ans.Online = true;
            }

            await _context.SaveChangesAsync();
            
        }
    }
}
