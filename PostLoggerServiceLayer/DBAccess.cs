using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;

namespace PostLoggerServiceLayer
{
    public class DBAccess
    {
        public DBAccess() { }

        public void PostData()
        {
            

        }

    }


    public class Logger
    {
        public long ID { get; set; }
        public string Level { get; set; }
        public DateTime Datetime { get; set; }
        public string Type { get; set; }
        public long EventId { get; set; }
    }




    public class EventLogging
    {
        public long EventId { get; set; }
        public string Location { get; set; }
        public string Server { get; set; }

    }

}



