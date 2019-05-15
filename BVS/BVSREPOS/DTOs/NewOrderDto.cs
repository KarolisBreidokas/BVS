using System;
using System.Collections.Generic;
using System.Text;

namespace BVS.Data.DTOs
{
    public class NewOrderDto
    {
        public DateTime Date;
        public int AuthorId;
        public ICollection<OrderedPartDto> PartList;
    }
}
