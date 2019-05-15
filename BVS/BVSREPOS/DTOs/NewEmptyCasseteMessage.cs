using BVS.Data.Models;

namespace BVS.Data.DTOs
{
    public class NewEmptyCasseteMessage : NewMessageDto
    {
        public int CartridgeId;
        public override ATM_Message fillMessage()
        {
            return new EmptyCasseteMessage()
            {
                Date = Date,
                AuthorId = AtmId,
                CartridgeId = CartridgeId
            };
        }
    }
}