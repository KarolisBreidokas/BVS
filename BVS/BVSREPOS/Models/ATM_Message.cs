
using System;
using System.ComponentModel.DataAnnotations;

/**
* @(#) ATM_Message.cs
*/
namespace BVS.Data.Models
{

    public abstract class ATM_Message
    {
        public ATM Autor { get; set; }

        public DateTime Date { get; set; }
        [Key]
        public int Id { get; set; }

    } 
}
