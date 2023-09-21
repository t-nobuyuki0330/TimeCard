using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCard.Info
{
    [ Serializable() ]
    public class UserInfo
    {
        //private string _user_no     = "";
        //private string _password    = "";
        //private string _name        = "";

        //public string UserNo
        //{
        //    get { return _user_no; }
        //    set { _user_no = value; }
        //}

        //public string Password
        //{
        //    get { return _password; }
        //    set { _password = value; }
        //}

        //public string Name
        //{
        //    get { return _name; }
        //    set { _name = value; }
        //}

        public string UserNo { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public UserInfo( string user_no, string password, string name )
        {
            UserNo      = user_no;
            Password    = password;
            Name        = name;
        }

        public UserInfo() : this ( "00000", "password", "名称未設定" )
        {
        }

        public UserInfo( string user_no, string password ) : this( user_no, password, "名称未設定" )
        {
        }
    }
}
