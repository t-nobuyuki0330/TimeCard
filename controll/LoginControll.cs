using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCard.info;
using TimeCard.utility;

namespace TimeCard.controll
{
    public class LoginControll
    {
        /// <summary>
        /// ローカルログインエラーコード
        /// </summary>
        public enum L_LOGIN_ERROR : UInt16
        {
            SUCCESS     = 0x0000,
            NO_USER     = 0x0001,
            MISS_PASS   = 0x0002,
            NO_USERINFO = 0x0003,
        }

        public static ( UserInfo user_info, bool admin_mode, L_LOGIN_ERROR error ) LocalCertification ( string user_no, string user_pass )
        {
            bool admin_mode = false;
            L_LOGIN_ERROR error = L_LOGIN_ERROR.SUCCESS;
            UserInfo user_info = null;

            var load_data = FileUtility.LoadBinaryFile( FileUtility.GetAppDataPath() + "\\info\\admin_info.dat" );
            UserInfo admin_info = ( UserInfo )load_data.file_data;

            
            if ( user_no == admin_info.UserNo )
            {
                if ( Sha256.CreateSHA256( user_pass ) == admin_info.Password )
                {
                    user_info = admin_info;
                    admin_mode = true;
                }
                else
                {
                    error = L_LOGIN_ERROR.MISS_PASS;
                }
            }
            else
            {
                if ( !File.Exists( FileUtility.GetAppDataPath() + "\\info\\users_info.dat" ) ) // なぜか結果が逆で返却される
                {
                    error = L_LOGIN_ERROR.NO_USERINFO;
                }
                else
                {
                    var load_users_data = FileUtility.LoadBinaryFile( FileUtility.GetAppDataPath() + "\\info\\users_info.dat" );
                    List< UserInfo > tmp = ( List< UserInfo > )load_users_data.file_data;

                    foreach ( UserInfo user in tmp )
                    {
                        if ( user_no == user.UserNo )
                        {
                            if ( Sha256.CreateSHA256( user_pass ) == user.Password )
                            {
                                user_info = user;
                            }
                            else
                            {
                                error = L_LOGIN_ERROR.MISS_PASS;
                            }
                            break;
                        }
                    }

                    if ( user_info == null )
                    {
                        error = L_LOGIN_ERROR.NO_USER;
                    }
                }
            }

            return ( user_info, admin_mode, error );
        }
    }
}
