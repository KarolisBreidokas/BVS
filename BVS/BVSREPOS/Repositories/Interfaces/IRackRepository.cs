/**
 * @(#) IRackRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IRackRepository
	{
        /**
		 * Paima ta sandelyje esancia bankomato dali, kuria ivede paieskoje
         * Kokia čia paieška?
		 */
        ICollection<PartInStorage> Select(  );
		
		/**
		 * Paima visas sandelyje esancias bankomato dalis
		 */
		ICollection<PartInStorage> SelectAll();
		
	}
	
}
