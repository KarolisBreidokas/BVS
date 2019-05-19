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
    public class MessageRepository:IMessageRepository
    {
        private readonly BVSDBContext _context;

        public MessageRepository(BVSDBContext context)
        {
            _context = context;
        }

        public ATM_Message GetMessage()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveMessage(NewMessageDto messageDto)
        {
            throw new NotImplementedException();
        }
    }
}
