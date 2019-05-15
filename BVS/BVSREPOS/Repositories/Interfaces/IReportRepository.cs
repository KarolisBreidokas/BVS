/**
 * @(#) IReportRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IReportRepository
	{
		void Create(  );
		
		/**
		 * Pajima visas ataskaitas pagal darbuotojo id
		 */
		ICollection<Report> getReportsOfEmployee(int id);
		
	}
	
}
