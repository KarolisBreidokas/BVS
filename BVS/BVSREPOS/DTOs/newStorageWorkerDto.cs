using System.ComponentModel.DataAnnotations;

namespace BVS.Data.DTOs
{
    public class newStorageWorkerDto:NewUserDto
    {

        [Phone]
        public string PhoneNo;
    }
}
