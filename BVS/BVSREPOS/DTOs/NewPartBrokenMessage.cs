using BVS.Data.Models;

namespace BVS.Data.DTOs
{
    public class NewPartBrokenMessage : NewMessageDto
    {
        public int PartId;
        public override ATM_Message fillMessage()
        {
            return new PartBrokenMessage()
            {
                Date = Date,
                AuthorId = AtmId,
                PartId = PartId
            };
        }
    }
}