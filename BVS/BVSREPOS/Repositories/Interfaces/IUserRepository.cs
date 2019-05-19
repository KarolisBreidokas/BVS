/**
 * @(#) IUserRepository.cs
 */

using System.Threading.Tasks;
using BVS.Data.DTOs;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<User> getUserInfo(int id);

        Task updateAccountInfo(int id,NewUserDto user);

        Task<int> createNewAccount(NewUserDto user);

        Task<User> checkData(LoginDto details);
		
	}
	
}
