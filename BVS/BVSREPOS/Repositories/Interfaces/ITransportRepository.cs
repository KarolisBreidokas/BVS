/**
 * @(#) ITransportRepository.cs
 */

namespace BVS.Data.Repositories.Interfaces
{
	public interface ITransportRepository
	{
		/**
		 * pajima visus pervežimus iš duombaz?s
		 */
		void getTransportations(  );
		
		/**
		 * Ieško pervežim? pagal nauj? adres?
		 */
		void search(  );
		
		/**
		 * sukuria nauj? pervežim?
		 */
		void createNewTransportation(  );
		
	}
	
}
