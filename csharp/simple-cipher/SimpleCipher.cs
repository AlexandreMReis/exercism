using System;
using System.Linq;

public class SimpleCipher
{
    public SimpleCipher()
    { 
        Random random= new Random();
        foreach (var _ in Enumerable.Range(0, 99))
        {
            Key += (char) random.Next(97, 122);
        }
    }

    public SimpleCipher(string key) => Key = key;

    public string Key { get; set; }

    public string Encode(string plaintext)
    {
        string output = string.Empty;
        if (string.IsNullOrEmpty(plaintext)) throw new ArgumentException();

        for(int i = 0; i <= plaintext.Length - 1; i++)
        {
            int shiftKey = Key[i % Key.Length] - 97;

            int result = 0;
            if (plaintext[i] >= 97 && plaintext[i] <= 122)
            {
                result = plaintext[i] + shiftKey;
                if (result > 122) result -= 26;
            }
            else if (plaintext[i] >= 65 && plaintext[i] <= 90)
            {
                result = plaintext[i] + shiftKey;
                if (result > 90) result -= 26;
            }
            else
            {
                result += plaintext[i];
            }
            output += (char)result;
        }

        return output;
    }

    public string Decode(string ciphertext)
    {
        string output = string.Empty;
        if (string.IsNullOrEmpty(ciphertext)) throw new ArgumentException();

        for (int i = 0; i <= ciphertext.Length - 1; i++)
        {
            int shiftKey = Key[i%Key.Length] - 97;

            int result = 0;
            if (ciphertext[i] >= 97 && ciphertext[i] <= 122)
            {
                result = ciphertext[i] - shiftKey;
                if (result < 97) result += 26;
            }
            else if (ciphertext[i] >= 65 && ciphertext[i] <= 90)
            {
                result = ciphertext[i] - shiftKey;
                if (result < 65) result += 26;
            }
            else
            {
                result += ciphertext[i];
            }
            output += (char)result;
        }

        return output;
    }
}