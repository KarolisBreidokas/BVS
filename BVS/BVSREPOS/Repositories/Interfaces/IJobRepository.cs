﻿/**
 * @(#) IJobRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.DTOs;
using System.Threading.Tasks;
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
		Task<int> CreateJob(NewJobDto message);      //REIKIA

        /**
		 * * Grąžina sąrašą darbų. //ar yra paieškos parametrai?
		 * * @return List<Job>
		 */
        Task<ICollection<Job>> SelectJobs(  );        //REIKIA

        /**
		 * * Atnaujina nurodyt? darb? b?senas ? "Tvarkomas". // ?
		 * * @param List<Job> jobs 
		 * * @return string - gražina errora arba patvirtinimo zinute.
		 */
        Task UpdateStatus(int JobId,JobState state);        //REIKIA

        //ar ne geriau būtų UpdateStatus išskirti į UpdateState ir Assign worker
        Task AssignWorker(int workerId,ICollection<int> jobIds);

    }
	
}
