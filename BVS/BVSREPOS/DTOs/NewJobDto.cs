using BVS.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BVS.Data.DTOs
{
    public class NewJobDto
    {
        public int MessageId;
        public string Description;
        public JobState State;

    }
}
