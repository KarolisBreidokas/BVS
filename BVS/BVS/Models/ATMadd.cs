using System;

namespace BVS.Models
{
    public class ATMadd
    {
        public string Address { get; set; }
        public string AdditionalInfo { get; set; }
        public int Error { get; set; }

        public ATMadd(string Address, string AdditionalInfo, int Error)
        {
            this.Address = Address;
            this.AdditionalInfo = AdditionalInfo;
            this.Error = Error;
        }
    }
}