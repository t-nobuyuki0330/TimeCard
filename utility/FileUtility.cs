using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

#pragma warning disable SYSLIB0011

namespace TimeCard.utility
{
    public class FileUtility
    {
        #region 定数定義
        public const string Sift_JIS    = "Shift_JIS";
        public const string UTF_8       = "UTF-8";
        public const string UTF_16      = "UTF-16";
        public const string ASCII       = "ASCII";

        #endregion

        #region 同期処理

        /// <summary>
        /// バイナリを復元
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>file_data ファイルの内容, success 実行結果</returns>
        public static ( object file_data, bool success ) LoadBinaryFile( string path )
        {
            FileStream fs = new FileStream( path, FileMode.Open, FileAccess.Read );
            object obj;
            bool success = false;

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                //読み込んで逆シリアル化する
                obj = formatter.Deserialize( fs );
                success = true;
            }
            catch ( Exception ex )
            {
                obj = ex.Message;
            }
            finally
            {
                fs.Close();
            }


            return ( obj, success );
        }

        /// <summary>
        /// オブジェクトの内容をファイルに保存する
        /// </summary>
        /// <param name="obj">保存するオブジェクト</param>
        /// <param name="path">保存先のファイル名</param>
        public static ( string message, bool success ) SaveBinaryFile( object obj, string path )
        {
            FileStream fs = new FileStream( path, FileMode.Create, FileAccess.Write );
            bool success = false;
            string message = "";

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                //シリアル化して書き込む
                formatter.Serialize( fs, obj );
                success = true;
            }
            catch ( Exception ex )
            {
                message = ex.Message;
            }
            finally
            {
                fs.Close();
            }

            return ( message, success );
        }

        /// <summary>
        /// ファイルすべて読み込み
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="char_type">文字コード</param>
        /// <returns>file_data ファイルの内容, success 実行結果</returns>
        public static ( string file_data, bool success ) ReadFileAll( string path, string char_type )
        {
            //読み込むテキストを保存する変数
            string file_data= "";

            try
            {
                //ファイルをオープンする
                using( StreamReader reader = new StreamReader( path, Encoding.GetEncoding( char_type ) ) )
                {
                    file_data = reader.ReadToEnd();
                }
            }
            catch ( Exception ex )
            {
                return ( ex.Message, false );
            }

            return ( file_data, true );
        }


        /// <summary>
        /// 一行ずつファイル読み込み
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="char_type">文字コード</param>
        /// <returns>file_data ファイルの内容, success 実行結果</returns>
        public ( List< string > file_data, bool success ) ReadFileLine( string path, string char_type )
        {
            List< string > lines = new List< string >();
            string line;
            bool success = false;

            try
            {
                //ファイルをオープンする
                using ( StreamReader reader = new StreamReader( path, Encoding.GetEncoding( char_type ) ) )
                {
                    while ( 0 <= reader.Peek() )
                    {
                        line = reader.ReadLine();
                        lines.Add( line );
                    }
                }
                success = true;
            }
            catch ( Exception ex )
            {
                lines.Clear();
                lines.Add( ex.Message );
            }

            return ( lines, success );
        }

        /// <summary>
        /// ファイルに書き込み
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="char_type">文字コード</param>
        /// <param name="overwrite">上書きするか</param>
        /// <param name="data">書き込みデータ</param>
        /// <returns>message エラーの内容, success 実行結果</returns>
        public static ( string message, bool success ) WriteFile( string path, string char_type, bool overwrite, string data )
        {
            bool success = false;
            string message = "";

            try
            {
                
                using ( StreamWriter writer = new StreamWriter( path, !overwrite, Encoding.GetEncoding( char_type ) ) )
                {
                    writer.Write( data );
                }
                success = true;
            }
            catch ( Exception ex )
            {
                message = ex.Message;
            }

            return ( message, success );
        }

        /// <summary>
        /// ファイルに書き込み(List)
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="char_type">文字コード</param>
        /// <param name="overwrite">上書きするか</param>
        /// <param name="data">書き込みデータ</param>
        /// <returns>message エラーの内容, success 実行結果</returns>
        public static ( string message, bool success ) WriteFile( string path, string char_type, bool overwrite, List< string > data )
        {
            bool success = false;
            string message = "";

            try
            {
                
                using ( StreamWriter writer = new StreamWriter( path, overwrite, Encoding.GetEncoding( char_type ) ) )
                {
                    foreach ( string line in data )
                    {
                        writer.WriteLine( line );
                    }
                }
                success = true;
            }
            catch ( Exception ex )
            {
                message = ex.Message;
            }

            return ( message, success );
        }

        #endregion

        public static string GetAppDataPath ()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            T GetCustomAttribute< T >() where T : Attribute => ( T )Attribute.GetCustomAttribute( asm, typeof( T ) );

            string asm_name = asm.GetName().Name;
            string company  = GetCustomAttribute< AssemblyCompanyAttribute >().Company;
            if ( company.Length == 0 )
            {
                company = "Default";
            }
            return Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ) + "\\" + company + "\\" + asm_name;

        }
    }
}
