
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey(nameof(Autor))]
        public int AuthorId { get; set; }

    } 
}
