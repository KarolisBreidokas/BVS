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
		
		int createNewAccount(NewUserDto user);
		
		bool checkData(string username,string password);
		
	}
	
}
