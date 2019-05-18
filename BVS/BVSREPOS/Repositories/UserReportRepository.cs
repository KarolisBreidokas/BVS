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
    public class UserReportRepository : IUserReportRepository
    {
        private readonly DbSet<UserReport> _userReports;
        private readonly BVSDBContext _context;

        public UserReportRepository(BVSDBContext context)
        {
            _context = context;
            _userReports = _context.UserReports;
        }

        public async Task<int> Add(NewUserReportDto reportDto)
        {
            var userReportEntity = new UserReport
            {
                Date = reportDto.Date,
                Description = reportDto.Description,
                UserId = reportDto.AuthorId
            };
            _userReports.Add(userReportEntity);
            await _context.SaveChangesAsync();
            return userReportEntity.Id;
        }
    }
}
