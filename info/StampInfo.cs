using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCard.Info;

namespace TimeCard.Info
{
    [ Serializable() ]
    public class StampInfo
    {
        public UserInfo User { get; set; }
        public List< string > Attend { get; set; }
        public List< string > Break { get; set; }
        public List< string > BreakEnd { get; set; }
        public List< string > Leaving { get; set; }

        public StampInfo( UserInfo user )
        {
            User = user;
            Attend = new List< string >();
            Break = new List< string >();
            BreakEnd = new List< string >();
            Leaving = new List< string >();
        }

    }
}
