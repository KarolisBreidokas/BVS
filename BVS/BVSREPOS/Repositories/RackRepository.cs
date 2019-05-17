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
    public class RackRepository : IRackRepository
    {
        private readonly DbSet<Rack> _racks;
        private readonly BVSDBContext _context;

        public RackRepository(BVSDBContext context)
        {
            _context = context;
            _racks = _context.Racks;
        }

        public ICollection<PartInStorage> Select()
        {
            throw new NotImplementedException();
        }

        public ICollection<PartInStorage> SelectAll()
        {
            throw new NotImplementedException();
        }
    }
}
