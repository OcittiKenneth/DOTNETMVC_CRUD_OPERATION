using System;
using System.Collections.Generic;
using System.Text;

namespace TEST.PROJECT
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IPAddress { get; set; }


    }
}
