using System.Collections.Generic;
using System.Linq;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return true;
        }
        Stack<char> charsStack = new ();
        foreach (char c in input)
        {
            switch (c) {
                case '(':
                case '{':
                case '[':
                    charsStack.Push (c);
                    break;
                case ')':
                    if (!charsStack.TryPop(out char foundChar1) || foundChar1 != '(') return false;
                    break;
                case '}':
                    if (!charsStack.TryPop(out char foundChar2) || foundChar2 != '{') return false;
                    break;
                case ']':
                    if (!charsStack.TryPop(out char foundChar3) || foundChar3 != '[') return false;
                    break;
                default: 
                    continue;
            }
        }
        return !charsStack.Any();
    }
}
