/**
 * @(#) ISubscriptionRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface ISubscriptionRepository
	{
		Subscription Get(int userId, int atmId);
		
		void Create(int userId,int atmId);          //REIKIA

        ICollection<User> GetByATM(int atmId);      //REIKIA

        bool Delete(int userId,int atmId);
		
		ICollection<ATM> GetByUser(int userId);     //REIKIA

    }
	
}
