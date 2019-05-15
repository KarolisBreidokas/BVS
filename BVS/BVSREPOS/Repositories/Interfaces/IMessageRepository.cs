/**
 * @(#) IMessageRepository.cs
 */

using BVS.Data.DTOs;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{
	public interface IMessageRepository
	{
		/**
		 * * išsaugo žinutę repositorijoje
		 * * @param Message
		 * * @return naujos žinutės id
		 */
		int SaveMessage(NewMessageDto messageDto);
		
		/**
		 * * Ištraukia žinut? iš rep. //pagal ką 
		 * * @param Message
		 * * @return Message
		 */
		ATM_Message GetMessage(  );
		
	}
	
}
