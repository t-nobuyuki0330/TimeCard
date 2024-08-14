using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCard.Info;
using TimeCard.Utility;

namespace TimeCard.Controller
{
    public class UserController
    {
        public static ( bool success, string message ) AddUser ( UserInfo add_user )
        {
            bool success = false;
            string message = "";

            // 管理者と同じ番号だったら禁止
            // if ( add_user.UserNo == ""

            if ( !File.Exists( InfoUri.UsersInfo ) )
            {
                List< UserInfo > user_list = new List< UserInfo >();
                user_list.Add( add_user );

                var result = FileUtility.SaveBinaryFile ( user_list, InfoUri.UsersInfo );
                if ( !result.success )
                {
                    message = result.message;
                }
                else
                {
                    success = true;
                    StampController.InitStampData( add_user );
                }
            }
            else
            {
                var users_data = FileUtility.LoadBinaryFile( InfoUri.UsersInfo );
                if ( users_data.file_data is List< UserInfo > )
                {
                    List< UserInfo > user_list = ( List< UserInfo > )users_data.file_data;
                    foreach ( UserInfo user in user_list )
                    {
                        if ( user.UserNo == add_user.UserNo )
                        {
                            message = "そのユーザーは既に登録されています";
                            break;
                        }
                    }

                    if ( message == "" )
                    {
                        user_list.Add( add_user );

                        var result = FileUtility.SaveBinaryFile ( user_list, InfoUri.UsersInfo );
                        if ( !result.success )
                        {
                            message = result.message;
                        }
                        else
                        {
                            success = true;
                            StampController.InitStampData( add_user );
                        }
                    }
                }
                else
                {
                    message = "ユーザー定義ファイルが破損しています";
                }
            }

            return ( success, message );
        }
    }
}
