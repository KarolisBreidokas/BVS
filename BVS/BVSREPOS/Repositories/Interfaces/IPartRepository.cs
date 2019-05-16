/**
 * @(#) IPartRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IPartRepository
	{
		/**
		 * Paima visas bankomato dalis
		 */
		ICollection<ATM_Part> Select(  );       //REIKIA

    }
	
}
