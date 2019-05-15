/**
 * @(#) IReportRepository.cs
 */

namespace BVS.Data.Repositories.Interfaces
{
	public interface IReportRepository
	{
		void Create(  );
		
		/**
		 * Pajima visas ataskaitas pagal darbuotojo id
		 */
		void getReportsOfEmployee(  );
		
	}
	
}
