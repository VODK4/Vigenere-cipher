sing System;
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
            Console.WriteLine("2.    Decryption");
            Console.WriteLine("3.    Key Exchange Test");
            methode_1 = Console.ReadLine();

            switch (methode_1)
            {
                case "1":
                    Console.Clear();
                    Encryption();
                    break;
                case "2":
                    Console.Clear();
                    Decryption();   
                    break;
                case "3":
                    Console.Clear();
                    KeyExchange();
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

            restart();
        }

        static void Decryption()
        {
            string encodedInput;
            int encodedInputLength;
            int encodedInputLength_ = 0;
            char process_1;
            string key;
            int keyLength;
            int keyLength_ = 0;
            char correspondingKey;

            Console.WriteLine("Enter encoded text:");
            encodedInput = Console.ReadLine();
            Console.WriteLine("Enter key:");
            key = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Encoded input:");
            Console.WriteLine(encodedInput);
            Console.WriteLine("Key:");
            Console.WriteLine(key);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Product:");

            encodedInputLength = encodedInput.Length;
            keyLength = key.Length;

            key = key.ToLower();
            key = key.Replace("ğ", "g");
            key = key.Replace("ü", "u");
            key = key.Replace("ş", "s");
            key = key.Replace("ı", "i");
            key = key.Replace("ö", "o");
            key = key.Replace("ç", "c");

            while (encodedInputLength_ != encodedInputLength)
            {
                if (keyLength_ < keyLength - 1)
                {
                    correspondingKey = key[keyLength_];

                    keyLength_++;
                }
                else
                {
                    correspondingKey = key[keyLength - 1];
                    keyLength_ = 0;
                }

                process_1 = encodedInput[encodedInputLength_];
                dictionaryDecrypt(process_1.ToString(), correspondingKey.ToString());
                encodedInputLength_++;
            }

            restart();
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

        static void dictionaryDecrypt(string input, string correspondingKey)
        {
            int keyAlphabetPos = alphabet.IndexOf(correspondingKey) + 1;
            int inputAlphabetPos = alphabet.IndexOf(input) + 1;

            if (alphabet.Contains(input))
            {
                input = (inputAlphabetPos - keyAlphabetPos).ToString();

                if (Int32.Parse(input) >= 1)
                {
                    input = alphabet[Int32.Parse(input)];
                }
                else
                {
                    input = alphabet[Int32.Parse(input) + 26];
                }
                Console.Write(input);
            }
            else
            {
                Console.Write(input);
            }
        }

        static void restart()
        {
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Do you want to continiue? (Y/N)");
            string choice = Console.ReadLine().ToLower();
            switch(choice)
            {
                case "y":
                    Main();
                    break;
                case "n":
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Unknown input.");
                    restart();
                    break;
            }
        }

        static void KeyExchange()
        {
            Random rnd = new Random();
            //Public
            int p = 0;
            int g = 0;

            bool pIsPrime = false;
            while (pIsPrime == false)
            {
                int number = rnd.Next(1, 100);

                if (IsPrime(number))
                {
                    p = number;
                    pIsPrime = true;
                }
                else
                {
                    pIsPrime = false;
                }
            }

            bool gIsPrime = false;
            while (gIsPrime == false)
            {
                int number = rnd.Next(1, 100);

                if (IsPrime(number))
                {
                    g = number;
                    gIsPrime = true;
                }
                else
                {
                    gIsPrime = false;
                }
            }

            //Private
            int C1 = rnd.Next(1,100);
            int C2 = rnd.Next(1,100);

            int aKeyPublic = toPower(g, C1, p) % p;
            int bKeyPublic = toPower(g, C2, p) % p;

            int aKey = toPower(bKeyPublic, C1, p) % p;
            int bKey = toPower(aKeyPublic, C2, p) % p;

            //Final
            Console.WriteLine("Key 1:    " + aKey);
            Console.WriteLine("Key 2:    " + bKey);

            if (aKey == bKey)
            {
                Console.WriteLine("Sucsess");
            }
            else
            {
                Console.WriteLine("Fail");
            }



            Console.ReadLine();
            KeyExchange();
            //restart();
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return false;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        static int toPower(int num1, int num2, int mod)
        {
            int cache = num1;
            for (int i = 1; i < num2; i++)
            {
                cache = (cache * num1) % mod;
            }
            return cache;
        }
    }
}
