using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCard.Info
{
    [ Serializable() ]
    public class DateInfo
    {
        public DateTime Date { get; set; }
        public DateTime Attend { get; set; }
        public DateTime Break { get; set; }
        public DateTime BreakEnd { get; set; }
        public DateTime Leaving { get; set; }

        public DateInfo ( DateTime date_time )
        {
            Date = date_time;
        }

        public DateInfo () : this( DateTime.Now ) {}

    }
}
