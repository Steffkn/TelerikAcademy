using System;
using System.Text;

class EncodingDecodingString
{
    static void Main()
    {
        string cipher = "hygtfrdeswaq";
        StringBuilder stringToEncDec = new StringBuilder();

        // get the string
        Console.WriteLine("Enter text to be encoded:");
        stringToEncDec.Append(Console.ReadLine());

        // encode the string
        string encodedString = EncodeDecode(stringToEncDec, cipher);
        Console.WriteLine("Encoded: {0}", encodedString);

        // clear the string builder and apped the endcoded string to it
        stringToEncDec.Clear();
        stringToEncDec.Append(encodedString);

        // decode the string
        string decodedString = EncodeDecode(stringToEncDec, cipher);
        Console.WriteLine("Decoded: {0}", decodedString);
    }

    /// <summary>
    /// Method that encodes/decodes text by given cipher.
    /// </summary>
    /// <param name="sbToEncode">StringBuilder type for the text</param>
    /// <param name="cipher">Encryption key</param>
    /// <returns>Returns an encoded string.</returns>
    public static string EncodeDecode(StringBuilder sbToEncode, string cipher)
    {
        StringBuilder encodedString = new StringBuilder();
        int cipherIndex = 0;

        // while the sb is not empty
        while (sbToEncode.Length != 0)
        {
            // append encoded char to the string builder
            encodedString.Append((char)(sbToEncode[0] ^ cipher[cipherIndex]));
            // if the end of the cipher is reached the index will become 0
            if (cipherIndex++ == cipher.Length - 1)
            {
                cipherIndex = 0;
            }
            // remove the encoded char from the string builder
            sbToEncode.Remove(0, 1);
        }
        // return the encoded string
        return encodedString.ToString();
    }
}
