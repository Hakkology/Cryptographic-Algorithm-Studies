using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS502_Substitution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Key = "YTNSHKVEFXRBAUQZCLWDMIPGJO";

            Console.WriteLine("Enter the text to be encoded: ");
            string Input = Console.ReadLine();
            Console.WriteLine(Encode(Input, Key));
            Console.ReadLine();
            Console.WriteLine(Decode(Encode(Input, Key), Key));
            Console.ReadLine();
        }


        static string Encode(string input, string key)
        {
            char[] charinputcheck=input.ToCharArray();
            char[] charinput = input.ToUpper().ToCharArray();
            char[] charkey = key.ToUpper().ToCharArray();
            char[] charoutput = new char[charinput.Length];
            //Encoding
            for (int i = 0; i < charinput.Length; i++)
            {
                if (charinput[i] ==' ' || Char.IsDigit(charinput[i]))
                {
                    charoutput[i] = charinput[i];
                }
                else
                {
                    int j = charinput[i] - 65;
                    charoutput[i] = charkey[j];
                }
            }
            //Case Sensitivity
            for (int i = 0; i < charoutput.Length; i++)
            {
                if (Char.IsLower(charinputcheck[i]))
                {
                    charoutput[i] = Char.ToLower(charoutput[i]);
                }
            }
            string Output = new string(charoutput);
            return Output;
        }

        static string Decode(string output, string key)
        {
            char[] charoutputcheck = output.ToCharArray();
            char[] charoutput = output.ToUpper().ToCharArray();
            char[] charkey = key.ToUpper().ToCharArray();
            char[] charinput = new char[charoutput.Length];
            //Decoding
            for (int i = 0; i < charoutput.Length; i++)
            {
                if (charoutput[i] == ' ' || Char.IsDigit(charoutput[i]))
                {
                    charinput[i] = charoutput[i];
                }
                else
                {
                    int j = key.IndexOf(charoutput[i]) + 65;
                    charinput[i] = (char)j;
                }
            }
            //Case Sensitivity
            for (int i = 0; i < charinput.Length; i++)
            {
                if (Char.IsLower(charoutputcheck[i]))
                {
                    charinput[i] = Char.ToLower(charinput[i]);
                }
            }
            string Input = new string(charinput);
            return Input;
        }
    }
}
