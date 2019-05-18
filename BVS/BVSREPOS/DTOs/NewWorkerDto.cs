using System.ComponentModel.DataAnnotations;
using BVS.Data.Models;

namespace BVS.Data.DTOs
{
    public class NewWorkerDto:NewUserDto
    {
        [Phone]
        public string PhoneNo;

        public Worker MapToWorker(Worker worker)
        {
            MapToUser(worker);
            worker.PhoneNo = PhoneNo;
            return worker;
        }
    }
}
