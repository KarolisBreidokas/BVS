/**
 * @(#) Job.cs
 */

namespace BVS.Data.Models
{
    public class Job
    {
        public string Description { get; set; }

        public JobState State { get; set; }

        public Worker Orders { get; set; }

        public Report Reports { get; set; }

        public AttentionNeededMessage Reason { get; set; }

        public int Id { get; set; }

    } 
}
