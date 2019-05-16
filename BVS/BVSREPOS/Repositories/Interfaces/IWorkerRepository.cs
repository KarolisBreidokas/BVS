/**
 * @(#) IWorkerRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.DTOs;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IWorkerRepository
	{
		/**
		 * Pajima darbuotojų duomenis parenka pagal id
		 */
		Worker getEmployee(int id);
		
		/**
		 * Pašalina darbuotoją iš duombazės pajima pagal id (prie kiekvieno darbuotojo bus delete mygtukas)
		 */
		bool delete(int id);
		
		/**
		 * Ieško darbuotojo pagal pavardę
		 */
		ICollection<Worker> search(string surname);     //REIKIA

        /**
		 * Sukuria nuają darbuotoją \\pridėti DTO klasę arba atrinti parametrus ar grąžinti sukurtą objektą?
		 */
        int createNewEmployee(NewWorkerDto workerDto);
		
		/**
		 * Pajima visus darbuotojus iš duomenų bazės
		 */
		ICollection<Worker> getEmployees();     //REIKIA

        /**
		 * Atnaujina darbuotojo duomenis parenka pagal id //worker DTO klasė +id
		 */
        void updateAccountInfo(int id,NewWorkerDto workerDto);
		
	}
	
}
