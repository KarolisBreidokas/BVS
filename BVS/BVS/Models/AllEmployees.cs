using System;
using System.Collections.Generic;
using BVS.Data.Models;

namespace BVS.Models
{
    public class AllEmployees
    {
        public ICollection<Worker> Worker { get; set; }
        public ICollection<StorageWorker> StorageWorker { get; set; }

        public AllEmployees(ICollection<Worker> Worker, ICollection<StorageWorker> StorageWorker)
        {
            this.Worker = Worker;
            this.StorageWorker = StorageWorker;
        }
    }
}