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
    public class TransportRepository:ITransportRepository
    {
        private readonly DbSet<ATM_Transport> _ATM_Transports;
        private readonly BVSDBContext _context;

        public TransportRepository(BVSDBContext context)
        {
            _context = context;
            _ATM_Transports = _context.ATM_Transports;
        }

        public int createNewTransportation(NewTransportDto transportDto)
        {
            throw new NotImplementedException();
        }

        public ICollection<ATM_Transport> getTransportations()
        {
            throw new NotImplementedException();
        }

        public ATM_Transport search(string newAddress)
        {
            throw new NotImplementedException();
        }
    }
}
