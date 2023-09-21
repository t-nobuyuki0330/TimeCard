using System;
using System.Windows;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCard.Utility;
using TimeCard.Info;

namespace TimeCard.Controller
{
    public class StampController
    {
        public static void InitStampData ( UserInfo user )
        {
            List< StampInfo > stamp_list;
            StampInfo stamp_info;
            if ( File.Exists( InfoUri.StampInfo ) )
            {
                var tmp = FileUtility.LoadBinaryFile ( InfoUri.StampInfo );
                if ( tmp.file_data is List< StampInfo > )
                {
                    stamp_list = ( List< StampInfo >)tmp.file_data;
                    foreach ( StampInfo stamp in stamp_list )
                    {
                        if ( stamp.User.UserNo == user.UserNo )
                        {
                            MessageBox.Show( "登録済みの為、初期化できません" );
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show( "データが破損しています" );
                    return;
                }
            }
            else
            {
                stamp_list = new List< StampInfo >();
            }

            stamp_info = new StampInfo( user );
            stamp_list.Add( stamp_info );

            FileUtility.SaveBinaryFile( stamp_list, InfoUri.StampInfo );
        }

        public static StampInfo LoadStampData( UserInfo user )
        {
            List< StampInfo > stamp_list;
            if ( File.Exists( InfoUri.StampInfo ) )
            {
                var tmp = FileUtility.LoadBinaryFile ( InfoUri.StampInfo );
                if ( tmp.file_data is List< StampInfo > )
                {
                    stamp_list = ( List< StampInfo > )tmp.file_data;
                }
                else
                {
                    MessageBox.Show( "データが破損しています" );
                    return null;
                }
            }
            else
            {
                return null;
            }

            return stamp_list.Find( stamp => stamp.User.UserNo.Equals( user.UserNo ) );
        }

        public static void SaveStampData( StampInfo stamp )
        {
            List< StampInfo > stamp_list;
            if ( File.Exists( InfoUri.StampInfo ) )
            {
                var tmp = FileUtility.LoadBinaryFile ( InfoUri.StampInfo );
                if ( tmp.file_data is List< StampInfo > )
                {
                    stamp_list = ( List< StampInfo >)tmp.file_data;
                }
                else
                {
                    MessageBox.Show( "データが破損しています" );
                    return;
                }
            }
            else
            {
                stamp_list = new List< StampInfo >();
            }

            for ( int i = 0; i < stamp_list.Count; i++ )
            {
                if ( stamp_list[ i ].User.UserNo.Equals( stamp.User.UserNo ) )
                {
                    stamp_list[ i ] = stamp;
                    FileUtility.SaveBinaryFile( stamp_list, InfoUri.StampInfo );
                    return;
                }
            }

            stamp_list.Add( stamp );
            FileUtility.SaveBinaryFile( stamp_list, InfoUri.StampInfo );
        }

        public static void Attend ( UserInfo user )
        {
            DateTime dt = DateTime.Now;
            StampInfo stamp = LoadStampData( user );
            if ( stamp == null ) stamp = new StampInfo( user );

            stamp.Attend.Add ( dt.ToString( "yyyy/MM/dd-HH:mm:ss" ) );

            SaveStampData( stamp );
        }

        public static void Break ( UserInfo user )
        {
            DateTime dt = DateTime.Now;
            StampInfo stamp = LoadStampData( user );
            if ( stamp == null ) stamp = new StampInfo( user );

            stamp.Break.Add ( dt.ToString( "yyyy/MM/dd-HH:mm:ss" ) );

            SaveStampData( stamp );
        }

        public static void BreakEnd ( UserInfo user )
        {
            DateTime dt = DateTime.Now;
            StampInfo stamp = LoadStampData( user );
            if ( stamp == null ) stamp = new StampInfo( user );

            stamp.BreakEnd.Add ( dt.ToString( "yyyy/MM/dd-HH:mm:ss" ) );

            SaveStampData( stamp );
        }

        public static void Leaving ( UserInfo user )
        {
            DateTime dt = DateTime.Now;
            StampInfo stamp = LoadStampData( user );
            if ( stamp == null ) stamp = new StampInfo( user );

            stamp.Leaving.Add ( dt.ToString( "yyyy/MM/dd-HH:mm:ss" ) );

            SaveStampData( stamp );
        }

    }
}
