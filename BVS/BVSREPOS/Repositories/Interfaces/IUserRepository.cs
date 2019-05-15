/**
 * @(#) IUserRepository.cs
 */

namespace BVS.Data.Repositories.Interfaces
{
	public interface IUserRepository
	{
		void getUserInfo(  );
		
		void updateAccountInfo(  );
		
		void createNewAccount(  );
		
		void checkData(  );
		
	}
	
}
