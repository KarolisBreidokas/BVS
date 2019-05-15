/**
 * @(#) IJobRepository.cs
 */

namespace BVS.Data.Repositories.Interfaces
{
	public interface IJobRepository
	{
		/**
		 * * sukuria nauja darba repositorijoje.
		 * * @param Job
		 * * @return string - pranesimas kad darbas sukurtas
		 */
		void CreateJob(  );
		
		/**
		 * * Gr?žina s?raš? darb?. 
		 * * @return List<Job>
		 */
		void SelectJobs(  );
		
		/**
		 * * Atnaujina nurodyt? darb? b?senas ? "Tvarkomas".
		 * * @param List<Job> jobs
		 * * @return string - gražina errora arba patvirtinimo zinute.
		 */
		void UpdateStatus(  );
		
	}
	
}
