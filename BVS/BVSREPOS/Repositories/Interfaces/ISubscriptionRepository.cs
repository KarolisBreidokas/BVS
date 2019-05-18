/**
 * @(#) ISubscriptionRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.Models;
using System.Threading.Tasks;

namespace BVS.Data.Repositories.Interfaces
{
	public interface ISubscriptionRepository
	{
		Task<Subscription> Get(int userId, int atmId);
		
		Task Create(int userId,int atmId);          //REIKIA

        Task<ICollection<User>> GetByATM(int atmId);      //REIKIA

        Task<bool> Delete(int userId, int atmId);
		
		Task<ICollection<ATM>> GetByUser(int userId);     //REIKIA

    }
	
}
