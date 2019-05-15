/**
 * @(#) IMessageRepository.cs
 */

namespace BVS.Data.Repositories.Interfaces
{
	public interface IMessageRepository
	{
		/**
		 * * i�saugo �inut? repositorijoje
		 * * @param Message
		 * * @return string - �inut? apie s?kminga i�saugojim? arba error
		 */
		void SaveMessage(  );
		
		/**
		 * * I�traukia �inut? i� rep.
		 * * @param Message
		 * * @return Message
		 */
		void GetMessage(  );
		
	}
	
}
