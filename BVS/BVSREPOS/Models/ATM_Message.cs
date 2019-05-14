
using System ;
/**
* @(#) ATM_Message.cs
*/
namespace BVS.Data.Models
{

    public abstract class ATM_Message
    {
        public ATM Autor { get; set; }

        public DateTime Date { get; set; }

        public int Id { get; set; }

    } 
}
