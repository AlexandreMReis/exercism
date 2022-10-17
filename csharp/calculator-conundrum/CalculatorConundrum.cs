using System;

public static class SimpleCalculator
{
    public static int Operator(this string operation, int operand1, int operand2)
    {
        switch (operation)
        {
            case "+": return operand1 + operand2;
            case "": throw new ArgumentException();
            case "*": return operand1 * operand2;
            case "/": return operand1 / operand2;
            case null: throw new ArgumentNullException();
            default: throw new ArgumentOutOfRangeException();
        }
    }

    public static string Calculate(int operand1, int operand2, string operation)
    {
        if (operand2 == 0 && operation == "/") return "Division by zero is not allowed.";
        return $"{operand1} {operation} {operand2} = {Operator(operation, operand1, operand2)}";
    }
}
