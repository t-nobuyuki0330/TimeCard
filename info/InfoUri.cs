using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCard.Utility;

namespace TimeCard.Info
{
    public class InfoUri
    {
        public static string AdminInfo  = FileUtility.GetAppDataPath() + "\\info\\admin_info.dat";
        public static string UsersInfo  = FileUtility.GetAppDataPath() + "\\info\\users_info.dat";
        public static string StampInfo  = FileUtility.GetAppDataPath() + "\\info\\stamp_info.dat";
        public static string CsvDir     = FileUtility.GetAppDataPath() + "\\csv";
    }
}
