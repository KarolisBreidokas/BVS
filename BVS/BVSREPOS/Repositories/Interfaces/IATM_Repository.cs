
using System.Collections.Generic;
using BVS.Data.DTOs;
using BVS.Data.Models;
using System.Threading.Tasks;

namespace BVS.Data.Repositories.Interfaces
{public interface IATM_Repository
	{
		/**
		 * Atnaujina bankomato dauomenis suranda bankomatą pagal id bus Dto ar viską per parametrus
		 */
		Task changeATMData(int id,NewATMDto atmDto);        //REIKIA

        /**
		 * Paima visus bankomatus is duombazes
		 */
        ICollection<ATM> getATMs(  );       //REIKIA
		
        //?
		bool Exists(int id);            //REIKIA

        /**
		 * Paima bankomatų iš duombazės pagal id
		 */

        Task<ATM> getATM( int id);        //REIKIA

        /**
		 * Ieško bankomato pagal adresą
		 */

        ICollection<ATM> search(string address);        //REIKIA

        /**
		 * Atnaujina specifinio bankomato duomenis parenka pagal id
		 */

        Task updateATMState(int atmId,ATM_State state);     //REIKIA

        /**
		 * Sukuria / ideda nauaj bankomata i duombaze
		 */

        Task<int> createNewATM(NewATMDto atmDto);     //REIKIA

        /**
		 * Pašalina bankomato iš duombazės pajima pagal adresą
		 * adresą????
		 */

        Task<bool> delete(int id);    //REIKIA
		
	}
	
}
