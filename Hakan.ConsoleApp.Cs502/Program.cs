using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakan.ConsoleApp.Cs502
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data;
            string code;
            int key;
            bool program = true;
            while (program)
            {
                Console.WriteLine("Şifrelemek mi yoksa şifreyi kırmak mı istiyorsunuz?");
                Console.Write("Şifrelemek için 1'i, kırmak için 2'ye, programdan çıkmak için başka herhangi bir tuşa basınız.");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Anahtar uzunluğunuzu belirleyin: ");
                        key = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Şifrelemek istediğiniz metni girin ");
                        data = Console.ReadLine();
                        char [] value = new char[data.Length];
                        for (int i = 0; i < data.Length; i++)
                        {
                            value[i] = (char)(data[i] + key);
                        }
                        string valuecoded = new string(value);
                        Console.Write(valuecoded);

                        break;
                    case 2:
                        Console.Write("Şifreli metninizi yazın: ");
                        code = Console.ReadLine();
                        Console.Write("Anahtar uzunluğunuzu belirleyin: ");
                        key = Convert.ToInt32(Console.ReadLine());
                        char[] keyvalue = new char[code.Length];
                        for (int i = 0; i < code.Length; i++)
                        {
                            keyvalue[i] = (char)(code[i] - key);
                        }
                        string keyvaluebreak = new string(keyvalue);
                        Console.Write(keyvaluebreak);

                        break;
                    default:
                        Console.Write("Şifrelemeyi kullandığınız için teşekkürler.");
                        program = false;
                        break;
                }
                Console.ReadLine();
            }

        }
    }
}
