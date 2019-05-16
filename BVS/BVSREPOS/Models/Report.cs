
using System ;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
* @(#) Report.cs
*/
namespace BVS.Data.Models
{

    public class Report
    {
        public Job Job { get; set; }

        public DateTime Date { get; set; }

        public string Body { get; set; }

        public bool Completed { get; set; }

        public Worker Author { get; set; }
        [Key]
        public int Id { get; set; }

        public int JobId { get; set; }

        public int WorkerId { get; set; }

    } 
}
