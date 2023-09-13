using System;

public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner)
    // TODO: complete the definition of the constructor
    {
        Operand1 = operand1;
        Operand2 = operand2;
        Message = message;
        InnerException= inner;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }

    public override string Message { get; }

    public new Exception InnerException { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try
        {
            this.Multiply(x, y);
            return "Multiply succeeded";
        }
        catch(CalculationException ex)
        {
            return ex.Message;
        }
    }

    public void Multiply(int x, int y)
    {
        try
        {
            this.calculator.Multiply(x, y);
        }
        catch(OverflowException e)
        {
            var specificMessage = x < 0 && y < 0 ? "Multiply failed for negative operands." : 
                                           "Multiply failed for mixed or positive operands.";
            throw new CalculationException(x, y, $"{specificMessage} {e.Message}", e);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
