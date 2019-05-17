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
    public class ReportRepository : IReportRepository
    {
        private readonly DbSet<Report> _reports;
        private readonly BVSDBContext _context;

        public ReportRepository(BVSDBContext context)
        {
            _context = context;
            _reports = _context.Reports;
        }

        public void Create(NewReportDto report)
        {
            throw new NotImplementedException();
        }

        public ICollection<Report> getReportsOfEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
