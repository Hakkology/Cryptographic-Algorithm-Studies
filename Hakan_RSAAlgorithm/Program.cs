using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Hakan_RSAAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var csp = new RSACryptoServiceProvider();
            var privateKey = csp.ExportParameters(true);
            var publicKey= csp.ExportParameters(false);

            string publicKeystring;
            {
                var sw = new System.IO.StringWriter();
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                xs.Serialize(sw, publicKey);
                publicKeystring=sw.ToString();
            }

            {
                var sr = new System.IO.StringReader(publicKeystring);
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                publicKey = (RSAParameters)xs.Deserialize(sr);
            }

            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(publicKey);

            var PlainText = "Run, you fools!";
            Console.WriteLine(PlainText);
            Console.ReadLine();
            var bytesPlainText = System.Text.Encoding.Unicode.GetBytes(PlainText);
            var bytesCypherText = csp.Encrypt(bytesPlainText, false);
            var cypherText = Convert.ToBase64String(bytesCypherText);
            Console.WriteLine(cypherText);
            Console.ReadLine();

            bytesCypherText = Convert.FromBase64String(cypherText);
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(privateKey);
            bytesPlainText = csp.Decrypt(bytesCypherText, false);
            PlainText = System.Text.Encoding.Unicode.GetString(bytesPlainText);
            Console.WriteLine(PlainText);
            Console.ReadLine();
        }
    }
}
