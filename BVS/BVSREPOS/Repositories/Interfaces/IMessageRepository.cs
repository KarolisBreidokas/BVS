/**
 * @(#) IMessageRepository.cs
 */

namespace BVS.Data.Repositories.Interfaces
{
	public interface IMessageRepository
	{
		/**
		 * * išsaugo žinutę repositorijoje
		 * * @param Message
		 * * @return bool - žinut? apie s?kminga išsaugojim? arba error //gausi išimtį arba true
		 */
		bool SaveMessage(  );
		
		/**
		 * * Ištraukia žinut? iš rep. //pagal ką 
		 * * @param Message
		 * * @return Message
		 */
		void GetMessage(  );
		
	}
	
}
