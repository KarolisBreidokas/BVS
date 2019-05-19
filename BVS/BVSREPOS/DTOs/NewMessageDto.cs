using System;
using System.Collections.Generic;
using System.Text;
using BVS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BVS.Data.DTOs
{
    public abstract class NewMessageDto
    {
        public int AtmId;
        public DateTime Date;
        public abstract ATM_Message fillMessage();
    }
}
