/**
 * @(#) IOrderRepository.cs
 */

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
		void Select(  );
		
	}
	
}
