/**
 * @(#) ITransportRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface ITransportRepository
	{
		/**
		 * paima visus pervežimus iš duombazės
		 */
		ICollection<ATM_Transport> getTransportations(  );
		
		/**
		 * Ieško pervežimo pagal naują adresą //?
		 */
		ATM_Transport search(string newAddress);
		
		/**
		 * sukuria naują pervežimą
		 */
		void createNewTransportation(  );
		
	}
	
}
