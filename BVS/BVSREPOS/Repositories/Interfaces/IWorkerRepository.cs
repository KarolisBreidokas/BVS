/**
 * @(#) IWorkerRepository.cs
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using BVS.Data.DTOs;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IWorkerRepository
	{
		/**
		 * Pajima darbuotojų duomenis parenka pagal id
		 */
		Task<Worker> getEmployee(int id);
		
		/**
		 * Pašalina darbuotoją iš duombazės pajima pagal id (prie kiekvieno darbuotojo bus delete mygtukas)
		 */
		Task<bool> delete(int id);
		
		/**
		 * Ieško darbuotojo pagal pavardę
		 */
		Task<ICollection<Worker>> search(string surname);     //REIKIA

        /**
		 * Sukuria nuają darbuotoją \\pridėti DTO klasę arba atrinti parametrus ar grąžinti sukurtą objektą?
		 */
        Task<int> createNewEmployee(NewWorkerDto workerDto);
		
		/**
		 * Pajima visus darbuotojus iš duomenų bazės
		 */
		Task<ICollection<Worker>> getEmployees();     //REIKIA

        /**
		 * Atnaujina darbuotojo duomenis parenka pagal id //worker DTO klasė +id
		 */
        Task updateAccountInfo(int id, NewWorkerDto workerDto);
		
	}
	
}
