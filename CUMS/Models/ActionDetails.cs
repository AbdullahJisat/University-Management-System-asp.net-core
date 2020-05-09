using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CUMS.Models
{
    public class ActionDetails
    {
        public string Action { get; set; }
        public string ActionDate { get; set; }
        public string ActionBy { get; set; }
        public int IsDelete { get; set; }
    }
}
