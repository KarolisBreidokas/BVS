
namespace BVS.Data.Repositories.Interfaces
{public interface IATM_Repository
	{
		/**
		 * Atnaujina bankomato dauomenis suranda bankomatą pagal id
		 */
		
		void changeData(  );
		
		/**
		 * Paima visus bankomatus is duombazes
		 */
		
		void getATMs(  );
		
		void Exists(  );
		
		/**
		 * Paima bankomatų iš duombazės pagal id
		 */
		
		void getATM(  );
		
		/**
		 * Ieško bankomato pagal adresą
		 */
		
		void search(  );
		
		/**
		 * Atnaujina specifinio bankomato duomenis parenka pagal id
		 */
		
		void updateATM(  );
		
		/**
		 * Sukuria / ideda nauaj bankomata i duombaze
		 */
		
		void createNewATM(  );
		
		/**
		 * Pašalina bankomato iš duombazės pajima pagal adresą
		 */
		
		void delete(  );
		
	}
	
}
