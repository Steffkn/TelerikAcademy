using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.EncodeEncrypt
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine(Encode("aaaabbbccccaa"));

            //Console.WriteLine((char)((((int)('B') - 65) ^ ((int)('B') - 65)) + (int)'A'));
            // get the string
            StringBuilder message = new StringBuilder();
            message.Append(Console.ReadLine());

            string cipher = Console.ReadLine();

            //message.Append( "ABC");
            //string cipher = "PQRST";

            // encode the string
            string cypherText = Encode(Encrypt(message, cipher) + cipher) + cipher.Length;

            Console.WriteLine(cypherText);

            // clear the string builder and apped the endcoded string to it
            //message.Clear();
            //message.Append(cypherText);
        }

        /// <summary>
        /// Method that encodes/decodes text by given cipher.
        /// </summary>
        /// <param name="sbToEncode">StringBuilder type for the text</param>
        /// <param name="cipher">Encryption key</param>
        /// <returns>Returns an encoded string.</returns>
        public static string Encrypt(StringBuilder sbToEncode, string cipher)
        {
            StringBuilder encodedString = new StringBuilder();
            int cipherIndex = 0;
            if (sbToEncode.Length >= cipher.Length)
            {
                // while the sb is not empty
                while (sbToEncode.Length != 0)
                {
                    // append encoded char to the string builder (char) ( ((int)('A') - 65) ^ ((int)('P') - 65) + 'A')
                    //Console.WriteLine   ((char)((((int)('B') - 65) ^ ((int)('B') - 65)) + (int)'A'));
                    encodedString.Append((char)((((int)sbToEncode[0] - 65) ^ ((int)cipher[cipherIndex] - 65)) + (int)'A'));
                    // if the end of the cipher is reached the index will become 0
                    if (cipherIndex++ == cipher.Length - 1)
                    {
                        cipherIndex = 0;
                    }
                    // remove the encoded char from the string builder
                    sbToEncode.Remove(0, 1);
                }
            }
            else
            {

                // while the sb is not empty
                while (true)
                {
                    // append encoded char to the string builder (char) ( ((int)('A') - 65) ^ ((int)('P') - 65) + 'A')
                    //Console.WriteLine   ((char)((((int)('B') - 65) ^ ((int)('B') - 65)) + (int)'A'));


                    encodedString.Append((char)((((int)sbToEncode[0] - 65) ^ ((int)cipher[cipherIndex] - 65)) + (int)'A'));
                    // if the end of the cipher is reached the index will become 0
                    if (cipherIndex++ == cipher.Length - 1)
                    {
                        // remove the encoded char from the string builder
                        sbToEncode.Remove(0, 1);
                        break;
                    }
                    // remove the encoded char from the string builder
                    sbToEncode.Remove(0, 1);
                    if (sbToEncode.Length == 0)
                    {
                        sbToEncode.Append(encodedString);
                        encodedString.Clear();
                    }
                }
            }
            // return the encoded string
            return encodedString.ToString() + sbToEncode.ToString();
        }



        public static string Encode(string text)
        {
            StringBuilder result = new StringBuilder();
            int counter = 1;
            for (int letterIndex = 0; letterIndex < text.Length; letterIndex++)
            {
                while (letterIndex < text.Length - 1 && text[letterIndex] == text[letterIndex + 1])
                {
                    counter++;
                    letterIndex++;
                }
                if (counter > 2)
                {
                    result.Append(counter);
                    result.Append(text[letterIndex]);
                }
                else if (counter == 2)
                {
                    result.Append(text[letterIndex]);
                    result.Append(text[letterIndex]);
                }
                else
                {
                    result.Append(text[letterIndex]);
                }
                counter = 1;
            }


            return result.ToString();
        }
    }
}
