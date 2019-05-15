/**
 * @(#) IReportRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.DTOs;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IReportRepository
	{
		void Create( NewReportDto report );
		
		/**
		 * Pajima visas ataskaitas pagal darbuotojo id
		 */
		ICollection<Report> getReportsOfEmployee(int id);
		
	}
	
}
