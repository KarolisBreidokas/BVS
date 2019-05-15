/**
 * @(#) IStorageWorkerRepository.cs
 */

namespace BVS.Data.Repositories.Interfaces
{
	public interface IStorageWorkerRepository
	{
		/**
		 * Sukuria nauj? sand?linink?
		 */
		void createNewStorageWorker(  );
		
		/**
		 * Pajima visus sand?lininkus i� duomen? baz?s
		 */
		void getStorageWorkers(  );
		
		/**
		 * Pajima sand?linink? pagal id
		 */
		void getStorageWorker(  );
		
		/**
		 * ie�ko darbuotoj? pagal pavard?
		 */
		void search(  );
		
		/**
		 * Pa�alina sand?linink? i� duomen? baz?s pagal id (prie kiekvieno sand?lininko bus delete mygtukas)
		 */
		void delete(  );
		
		/**
		 * Atnaujina sand?lininko duomenis parenka pagal id
		 */
		void updateStorageWorkerInfo(  );
		
	}
	
}
