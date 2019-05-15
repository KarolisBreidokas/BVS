/**
 * @(#) IOrderRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IOrderRepository
	{
		/**
		 * Prideda uzsakyma i duombaze
		 */
		void AddOrder(  );
		
		/**
		 * Paima visus uzsakymus is duombazes
		 */
		ICollection<Order> Select(  );
		
	}
	
}
