/**
 * @(#) ISubscriptionRepository.cs
 */

namespace BVS.Data.Repositories.Interfaces
{
	public interface ISubscriptionRepository
	{
		void Get(  );
		
		void Create(  );
		
		void GetByATM(  );
		
		void Delete(  );
		
		void GetByUser(  );
		
	}
	
}
