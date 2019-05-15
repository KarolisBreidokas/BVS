/**
 * @(#) IJobRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IJobRepository
	{
		/**
		 * * sukuria nauja darba repositorijoje.
		 * * @param Job
		 * * @return int - naujo darbo id
		 */
		int CreateJob(AttentionNeededMessage message);
		
		/**
		 * * Grąžina sąrašą darbų. //ar yra paieškos parametrai?
		 * * @return List<Job>
		 */
		ICollection<Job> SelectJobs(  );
		
		/**
		 * * Atnaujina nurodyt? darb? b?senas ? "Tvarkomas". // ?
		 * * @param List<Job> jobs
		 * * @return string - gražina errora arba patvirtinimo zinute.
		 */
		void UpdateStatus(JobState state);

        //ar ne geriau būtų UpdateStatus išskirti į UpdateState ir Assign worker
        void AssignWorker(int workerId);

    }
	
}
