/**
 * @(#) IMessageRepository.cs
 */

using BVS.Data.DTOs;
using BVS.Data.Models;
using System.Threading.Tasks;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IMessageRepository
	{
		/**
		 * * išsaugo žinutę repositorijoje
		 * * @param Message
		 * * @return naujos žinutės id
		 */
		Task<int> SaveMessage(NewMessageDto messageDto);  //REIKIA

        /**
		 * * Ištraukia žinut? iš rep. //pagal ką 
		 * * @param Message
		 * * @return Message
		 */
        Task<ATM_Message> GetMessage(int id);     //REIKIA

    }
	
}
