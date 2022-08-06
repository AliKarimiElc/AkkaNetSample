using Akka.Actor;

public class CalculatorActor : ReceiveActor
{
    public CalculatorActor()
    {
        Receive<Add>(add =>
        {
            Console.WriteLine($"Receive {nameof(add)} operation .... ");
            Console.WriteLine($"Result is : {add.Execute().OperationResult}");
        });

        Receive<Minus>(add =>
        {
            Console.WriteLine($"Receive {nameof(add)} operation .... ");
            Console.WriteLine($"Result is : {add.Execute().OperationResult}");
        });
    }
}

public interface IOperation
{
    public Result Execute();
}

public class Add : IOperation
{
    public Add(double operandA, double operandB)
    {
        OperandA = operandA;
        OperandB = operandB;
    }

    public double OperandA { get; }
    public double OperandB { get; }
    public Result Execute()
    {
        return new Result(OperandA + OperandB);
    }
}

public class Minus : IOperation
{
    public Minus(double operandA, double operandB)
    {
        OperandA = operandA;
        OperandB = operandB;
    }

    public double OperandA { get; }
    public double OperandB { get; }
    public Result Execute()
    {
        return new Result(OperandA - OperandB);
    }
}

public class Result
{
    public Result(double operationResult)
    {
        OperationResult = operationResult;
    }

    public double OperationResult { get; set; }
}