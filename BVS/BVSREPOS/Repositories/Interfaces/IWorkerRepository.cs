/**
 * @(#) IWorkerRepository.cs
 */

namespace BVS.Data.Repositories.Interfaces
{
	public interface IWorkerRepository
	{
		/**
		 * Pajima darbuotoj? parenka pagal id
		 */
		void getEmployee(  );
		
		/**
		 * Pa�alina darbuotoj? i� duombaz?s pajima pagal id (prie kiekvieno darbuotojo bus delete mygtukas)
		 */
		void delete(  );
		
		/**
		 * Ie�ko darbuotoj? pagal pavard?
		 */
		void search(  );
		
		/**
		 * Sukuria nuaj? darbuotoj?
		 */
		void createNewEmployee(  );
		
		/**
		 * Pajima visus darbuotojus i� duomen? baz?s
		 */
		void getEmployees(  );
		
		/**
		 * Atnaujina darbuotojo duomenis parenka pagal id
		 */
		void updateAccountInfo(  );
		
	}
	
}
