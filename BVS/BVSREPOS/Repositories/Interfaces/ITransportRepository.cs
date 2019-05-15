/**
 * @(#) ITransportRepository.cs
 */

namespace BVS.Data.Repositories.Interfaces
{
	public interface ITransportRepository
	{
		/**
		 * pajima visus perve�imus i� duombaz?s
		 */
		void getTransportations(  );
		
		/**
		 * Ie�ko perve�im? pagal nauj? adres?
		 */
		void search(  );
		
		/**
		 * sukuria nauj? perve�im?
		 */
		void createNewTransportation(  );
		
	}
	
}
