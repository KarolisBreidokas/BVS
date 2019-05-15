﻿/**
 * @(#) IStorageWorkerRepository.cs
 */

using System.Collections.Generic;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IStorageWorkerRepository
	{
		/**
		 * Sukuria naują sandėlininką
		 */
		void createNewStorageWorker(  );
		
		/**
		 * Pajima visus sandėlininkus iš duomenų bazės
		 */
		ICollection<StorageWorker> getStorageWorkers(  );

        /**
		 * Pajima sandėlininką pagal id
		 */
        StorageWorker getStorageWorker(int id);
		
		/**
		 * ieško darbuotojų pagal pavardę
		 */
		ICollection<StorageWorker> search(string surname);
		
		/**
		 * Pašalina sandėlininką iš duomen bazės pagal id
		 */
		void delete(int id);
		
		/**
		 * Atnaujina sandėlininko duomenis parenka pagal id
		 */
		void updateStorageWorkerInfo();
		
	}
	
}
