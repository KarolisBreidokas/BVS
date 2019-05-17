/**
 * @(#) IUserReportRepository.cs
 */

using BVS.Data.DTOs;
using System.Threading.Tasks;

namespace BVS.Data.Repositories.Interfaces
{
    public interface IUserReportRepository
    {
        Task<int> Add(NewUserReportDto reportDto);      // TURBUT SITO REIKIA MAGIC DRAW YRA CREATE NEW REPORS

    }

}
