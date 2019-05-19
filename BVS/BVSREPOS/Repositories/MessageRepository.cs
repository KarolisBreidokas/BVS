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
        private readonly DbSet<ATM_Message> _messages;

        public MessageRepository(BVSDBContext context)
        {
            _context = context;
            _messages = _context.atmMessages;
        }

        public ATM_Message GetMessage() // pagal ką išrinkti
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveMessage(NewMessageDto messageDto)
        {
            var ans = messageDto.fillMessage();
            _messages.Add(ans);
            await _context.SaveChangesAsync();
            return ans.Id;
        }
    }
}
