using BVS.Data.DTOs;
using BVS.Data.Models;
/**
 * @(#) IStorageWorkerRepository.cs
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BVS.Data.Repositories.Interfaces
{
    public interface IStorageWorkerRepository
    {
        /**
		 * Sukuria naują sandėlininką
		 */
        Task createNewStorageWorker(newStorageWorkerDto workerDto);

        /**
		 * Pajima visus sandėlininkus iš duomenų bazės
		 */
        Task<ICollection<StorageWorker>> getStorageWorkers();       //REIKIA

        /**
		 * Pajima sandėlininką pagal id
		 */
        Task<StorageWorker> getStorageWorker(int id);

        /**
		 * ieško darbuotojų pagal pavardę
		 */
        Task<ICollection<StorageWorker>> search(string surname);      //REIKIA

        /**
		 * Pašalina sandėlininką iš duomen bazės pagal id
		 */
        Task<bool> delete(int id);

        /**
		 * Atnaujina sandėlininko duomenis parenka pagal id
		 */
        Task updateStorageWorkerInfo(int id, newStorageWorkerDto workerDto);

    }

}
