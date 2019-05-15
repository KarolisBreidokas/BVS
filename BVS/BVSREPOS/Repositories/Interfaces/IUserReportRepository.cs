/**
 * @(#) IUserReportRepository.cs
 */

using BVS.Data.DTOs;

namespace BVS.Data.Repositories.Interfaces
{
    public interface IUserReportRepository
    {
        void Add(NewUserReportDto reportDto);

    }

}
