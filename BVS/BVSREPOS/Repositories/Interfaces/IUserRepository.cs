/**
 * @(#) IUserRepository.cs
 */

using BVS.Data.DTOs;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IUserRepository
	{
		User getUserInfo(int id);
		
		void updateAccountInfo(int id,NewUserDto user);
		
		void createNewAccount(NewUserDto user);
		
		void checkData(string username,string password);
		
	}
	
}
