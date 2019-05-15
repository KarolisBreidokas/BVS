using BVS.Data.Models;

namespace BVS.Data.DTOs
{
    public class NewInformationalMessageDto : NewMessageDto
    {
        public string Body;
        public override ATM_Message fillMessage()
        {
            return new InformationalMessage()
            {
                Date = Date,
                AuthorId = AtmId,
                Body = Body
            };
        }
    }
}