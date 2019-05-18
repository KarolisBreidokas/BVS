/**
 * @(#) IOrderRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.DTOs;
using BVS.Data.Models;
using System.Threading.Tasks;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IOrderRepository
	{
		/**
		 * Prideda uzsakyma i duombaze
		 */
		Task<int> AddOrder(NewOrderDto orderDto);     //REIKIA

        /**
		 * Paima visus uzsakymus is duombazes
		 */
        Task<ICollection<Order>> Select(  );      //REIKIA

    }
	
}
