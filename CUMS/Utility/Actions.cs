using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CUMS.Utility
{
    public static class Actions
    {
        public static string ActionInsert { get; set; }
        public static string ActionUpdate { get; set; }
        public static string ActionRemove { get; set; }

        static Actions()
        {
            ActionInsert = "INSERTED";
            ActionUpdate = "UPDATED";
            ActionRemove = "REMOVED";
        }
    }
}