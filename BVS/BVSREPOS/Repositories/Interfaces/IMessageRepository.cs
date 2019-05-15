/**
 * @(#) IMessageRepository.cs
 */

namespace BVS.Data.Repositories.Interfaces
{
	public interface IMessageRepository
	{
		/**
		 * * išsaugo žinut? repositorijoje
		 * * @param Message
		 * * @return string - žinut? apie s?kminga išsaugojim? arba error
		 */
		void SaveMessage(  );
		
		/**
		 * * Ištraukia žinut? iš rep.
		 * * @param Message
		 * * @return Message
		 */
		void GetMessage(  );
		
	}
	
}
