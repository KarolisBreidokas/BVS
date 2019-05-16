/**
 * @(#) Job.cs
 */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BVS.Data.Models
{
    public class Job
    {
        public string Description { get; set; }

        public JobState State { get; set; }

        public Worker AssignedWorker { get; set; }

        public ICollection<Report> Reports { get; set; }

        public AttentionNeededMessage Reason { get; set; }
        [Key]
        public int Id { get; set; }
        public int? WorkerId { get; set; }
        public int? MessageId { get; set; }

    } 
}
