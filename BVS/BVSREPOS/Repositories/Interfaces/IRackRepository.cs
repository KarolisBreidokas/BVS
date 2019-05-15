/**
 * @(#) IRackRepository.cs
 */

namespace BVS.Data.Repositories.Interfaces
{
	public interface IRackRepository
	{
		/**
		 * Paima ta sandelyje esancia bankomato dali, kuria ivede paieskoje
		 */
		void Select(  );
		
		/**
		 * Paima visas sandelyje esancias bankomato dalis
		 */
		void SelectAll(  );
		
	}
	
}
