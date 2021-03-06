﻿using System;
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
    public class PartRepository:IPartRepository
    {
        private readonly DbSet<ATM_Part> _ATM_parts;
        private readonly BVSDBContext _context;

        public PartRepository(BVSDBContext context)
        {
            _context = context;
            _ATM_parts = _context.ATM_Parts;
        }

        public async Task<ICollection<ATM_Part>> Select()
        {
            var ans = await _ATM_parts.ToListAsync();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }
    }
}
