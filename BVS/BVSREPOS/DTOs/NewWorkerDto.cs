using System.ComponentModel.DataAnnotations;

namespace BVS.Data.DTOs
{
    public class NewWorkerDto:NewUserDto
    {
        [Phone]
        public string PhoneNo;
    }
}
