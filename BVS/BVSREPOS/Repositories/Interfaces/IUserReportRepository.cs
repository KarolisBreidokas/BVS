/**
 * @(#) IUserReportRepository.cs
 */

using BVS.Data.DTOs;

namespace BVS.Data.Repositories.Interfaces
{
    public interface IUserReportRepository
    {
        int Add(NewUserReportDto reportDto);

    }

}
