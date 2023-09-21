using System.Text;
using System.Security.Cryptography;

#pragma warning disable SYSLIB0021

namespace TimeCard.Utility
{
    internal class Sha256
    {
        public static string CreateSHA256( string password )
        {
            StringBuilder sb = new StringBuilder();
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            byte[] ByteArray = Encoding.UTF8.GetBytes( password );

            ByteArray = sha256.ComputeHash( ByteArray );
            sha256.Clear();

            foreach( byte b in ByteArray )
            {
                sb.Append( b.ToString( "x2" ) );
            }

            return sb.ToString();
        }
    }
}
