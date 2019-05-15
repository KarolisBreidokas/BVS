
using System.Collections.Generic;
using BVS.Data.DTOs;
using BVS.Data.Models;

namespace BVS.Data.Repositories.Interfaces
{public interface IATM_Repository
	{
		/**
		 * Atnaujina bankomato dauomenis suranda bankomatą pagal id bus Dto ar viską per parametrus
		 */
		void changeATMData(int id,NewATMDto atmDto);
		
		/**
		 * Paima visus bankomatus is duombazes
		 */
		ICollection<ATM> getATMs(  );
		
        //?
		bool Exists(int id);
		
		/**
		 * Paima bankomatų iš duombazės pagal id
		 */
		
		ATM getATM( int id);
		
		/**
		 * Ieško bankomato pagal adresą
		 */
		
		ICollection<ATM> search(string address);
		
		/**
		 * Atnaujina specifinio bankomato duomenis parenka pagal id
		 */
		
		void updateATMState(int atmId,ATM_State state);
		
		/**
		 * Sukuria / ideda nauaj bankomata i duombaze
		 */
		
		int createNewATM(NewATMDto atmDto);
		
		/**
		 * Pašalina bankomato iš duombazės pajima pagal adresą
		 * adresą????
		 */
		
		bool delete(int id);
		
	}
	
}
