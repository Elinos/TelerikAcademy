/***************************************************************
 * 
 * 7. Write a program that encodes and decodes a string 
 * using given encryption key (cipher). The key consists 
 * of a sequence of characters. The encoding/decoding 
 * is done by performing XOR (exclusive or) operation 
 * over the first letter of the string with the first of the 
 * key, the second – with the second, etc. When the 
 * last key character is reached, the next is the first.
 * 
 ***************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class XORCipher
{
    static void Main()
    {
        string strToEncodeOrDecode = Console.ReadLine();
        string key = Console.ReadLine();
        Console.WriteLine(EncodeOrDecode(strToEncodeOrDecode, key));
    }

    static string EncodeOrDecode(string strToEncode, string key)
    {
        StringBuilder encodedStr = new StringBuilder();
        for (int i = 0; i < strToEncode.Length; i++)
        {
            encodedStr.Append((char)((strToEncode[i] ^ key[i % key.Length]) % 26 + 0x61)); //encode / decode only as letters
        }

        return encodedStr.ToString();
    }
}
