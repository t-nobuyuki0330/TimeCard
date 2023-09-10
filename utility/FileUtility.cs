using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

#pragma warning disable SYSLIB0011

namespace TimeCard.utility
{
    public class FileUtility
    {
        /// <summary>
        /// バイナリを復元
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>オブジェクト</returns>
        public static object LoadFromBinaryFile( string path )
        {
            FileStream fs = new FileStream( path, FileMode.Open, FileAccess.Read );
            BinaryFormatter formatter = new BinaryFormatter();
            //読み込んで逆シリアル化する
            object obj = formatter.Deserialize( fs );
            fs.Close();

            return obj;
        }

        /// <summary>
        /// オブジェクトの内容をファイルに保存する
        /// </summary>
        /// <param name="obj">保存するオブジェクト</param>
        /// <param name="path">保存先のファイル名</param>
        public static void SaveToBinaryFile( object obj, string path )
        {
            FileStream fs = new FileStream( path, FileMode.Create, FileAccess.Write );
            BinaryFormatter formatter = new BinaryFormatter();
            //シリアル化して書き込む
            formatter.Serialize( fs, obj );
            fs.Close();
        }
    }
}
