/**
 * @(#) IPartRepository.cs
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IPartRepository
	{
		/**
		 * Paima visas bankomato dalis
		 */
		Task<ICollection<ATM_Part>> Select(  );       //REIKIA

    }
	
}
