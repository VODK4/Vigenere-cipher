using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Encryption
{
    internal class Program
    {
        static List<string> alphabet = new List<string>() { 
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

        static void Main()
        {
            Console.Clear();
            string methode_1;
            Console.WriteLine("Encryption 0.1 Experimental build\n");
            Console.WriteLine("Chose Methode:");
            Console.WriteLine("1.    Encryption");
            methode_1 = Console.ReadLine();

            switch (methode_1)
            {
                case "1":
                    Console.Clear();
                    Encryption();
                    break;
            }
        }

        static void Encryption()
        {
            string rawInput;
            int rawInputLength;
            int rawInputLength_ = 0;
            char process_1;
            string key;
            int keyLength;
            int keyLength_ = 0;
            char correspondingKey;

            Console.WriteLine("Enter plain text:");
            rawInput = Console.ReadLine();
            Console.WriteLine("Enter key:");
            key = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Raw input:");
            Console.WriteLine(rawInput);
            Console.WriteLine("Key:");
            Console.WriteLine(key);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Product:");

            rawInputLength = rawInput.Length;
            keyLength = key.Length;

            rawInput = rawInput.ToLower();
            rawInput = rawInput.Replace("ğ", "g");
            rawInput = rawInput.Replace("ü", "u");
            rawInput = rawInput.Replace("ş", "s");
            rawInput = rawInput.Replace("ı", "i");
            rawInput = rawInput.Replace("ö", "o");
            rawInput = rawInput.Replace("ç", "c");

            key = key.ToLower();
            key = key.Replace("ğ", "g");
            key = key.Replace("ü", "u");
            key = key.Replace("ş", "s");
            key = key.Replace("ı", "i");
            key = key.Replace("ö", "o");
            key = key.Replace("ç", "c");

            

            while (rawInputLength_ != rawInputLength)
            {
                //Console.WriteLine(keyLength + " - " + keyLength_);

                if (keyLength_ < keyLength - 1)
                {
                    correspondingKey = key[keyLength_];

                    keyLength_++;
                }
                else //if (keyLength_ == keyLength)
                {
                    correspondingKey = key[keyLength - 1];
                    keyLength_ = 0;
                }

                process_1 = rawInput[rawInputLength_];
                dictionaryEncrypt(process_1.ToString(), correspondingKey.ToString());
                rawInputLength_++;
            }

            Console.Read();
        }

        static void dictionaryEncrypt(string input, string correspondingKey)
        {

            int keyAlphabetPos = alphabet.IndexOf(correspondingKey) + 1;
            int inputAlphabetPos = alphabet.IndexOf(input) + 1;

            //Console.WriteLine(input+","+inputAlphabetPos+" - "+correspondingKey+","+keyAlphabetPos);

            if (alphabet.Contains(input))
            {
                input = (inputAlphabetPos + keyAlphabetPos).ToString();

                if (Int32.Parse(input) <= 28)
                {
                    input = alphabet[Int32.Parse(input) - 2];
                }
                else
                {
                    input = alphabet[Int32.Parse(input) - 28];
                }
                Console.Write(input);
            }
            else if (input == " ")
            {
                input = "";
            }
            else
            {
                Console.Write(input);
            }
        }
    }
}
