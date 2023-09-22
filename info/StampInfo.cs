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
        public List< DateInfo > Stamp { get; set; }

        public StampInfo( UserInfo user )
        {
            User = user;
            Stamp = new List< DateInfo >();
        }

    }
}
