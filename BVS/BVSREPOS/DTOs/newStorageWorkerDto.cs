using System.ComponentModel.DataAnnotations;
using BVS.Data.Models;

namespace BVS.Data.DTOs
{
    public class newStorageWorkerDto:NewUserDto
    {

        [Phone]
        public string PhoneNo;

        public StorageWorker MapToStorageWorker(StorageWorker worker)
        {
            MapToUser(worker);
            worker.PhoneNo = PhoneNo;
            return worker;
        }
    }
}
