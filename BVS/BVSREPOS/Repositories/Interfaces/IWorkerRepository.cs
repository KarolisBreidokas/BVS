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
		 * Pašalina darbuotoj? iš duombaz?s pajima pagal id (prie kiekvieno darbuotojo bus delete mygtukas)
		 */
		void delete(  );
		
		/**
		 * Ieško darbuotoj? pagal pavard?
		 */
		void search(  );
		
		/**
		 * Sukuria nuaj? darbuotoj?
		 */
		void createNewEmployee(  );
		
		/**
		 * Pajima visus darbuotojus iš duomen? baz?s
		 */
		void getEmployees(  );
		
		/**
		 * Atnaujina darbuotojo duomenis parenka pagal id
		 */
		void updateAccountInfo(  );
		
	}
	
}
