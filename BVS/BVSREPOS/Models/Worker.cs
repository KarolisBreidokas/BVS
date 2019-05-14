/**
 * @(#) Worker.cs
 */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BVS.Data.Models
{
    public class Worker : User
    {
        [Phone]
        public string PhoneNo { get; set; }

        public ICollection<Job> AssignedJobs { get; set; }

    }

}