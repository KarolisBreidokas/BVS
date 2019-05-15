/**
 * @(#) IOrderRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.DTOs;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IOrderRepository
	{
		/**
		 * Prideda uzsakyma i duombaze
		 */
		void AddOrder(NewOrderDto orderDto);
		
		/**
		 * Paima visus uzsakymus is duombazes
		 */
		ICollection<Order> Select(  );
		
	}
	
}
