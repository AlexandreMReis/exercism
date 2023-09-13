public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        string output = string.Empty;
        foreach (char c in text)
        {
            int result = 0;
            if(c >= 97 && c <= 122)
            {
                result = c + shiftKey;
                if (result > 122) result -= 26;
            }
            else if(c >= 65 && c <= 90)
            {
                result = c + shiftKey;
                if (result > 90) result -= 26;
            }
            else
            {
                result += c;
            }
            output+= (char) result;
        }
        return output;
    }
}