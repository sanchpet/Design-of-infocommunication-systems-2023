var calculator = new Calculator();
double result = 0;
result = calculator.Add(5);
Console.WriteLine(result);
result = calculator.Add(4);
Console.WriteLine(result);
result = calculator.Add(3);
Console.WriteLine(result);
result = calculator.Redo();
Console.WriteLine(result);
result = calculator.Undo();
Console.WriteLine(result);

abstract class Command
{
    protected ArithmeticUnit unit;
    protected double operand;
    public abstract void Execute();
    public abstract void UnExecute();
}

class ArithmeticUnit
{
    public double Register { get; private set; }
    public void Run(char operationCode, double operand)
    {
        switch (operationCode)
        {
            case '+':
                Register += operand;
                break;
            case '-':
                Register -= operand;
                break;
            case '*':
                Register *= operand;
                break;
            case '/':
                Register /= operand;
                break;
        }
    }
}

class ControlUnit
{
    private List<Command> commands = new List<Command>();
    private int current = 0;
    public void StoreCommand(Command command)
    {
        commands.Add(command);
    }
    public void ExecuteCommand()
    {
        commands[current].Execute();
        current++;
    }
    public void Undo()
    {
        commands[current - 1].UnExecute();
    }
    public void Redo()
    {
        commands[current - 1].Execute();
    }
}

class Add : Command
{
    public Add(ArithmeticUnit unit, double operand)
    {
        this.unit = unit;
        this.operand = operand;
    }
    public override void Execute()
    {
        unit.Run('+', operand);
    }
    public override void UnExecute()
    {
        unit.Run('-', operand);
    }
}

class Substract : Command
{
    public Substract(ArithmeticUnit unit, double operand)
    {
        this.unit = unit;
        this.operand = operand;
    }
    public override void Execute()
    {
        unit.Run('-', operand);
    }
    public override void UnExecute()
    {
        unit.Run('+', operand);
    }
}

class Multiply : Command
{
    public Multiply(ArithmeticUnit unit, double operand)
    {
        this.unit = unit;
        this.operand = operand;
    }
    public override void Execute()
    {
        unit.Run('*', operand);
    }
    public override void UnExecute()
    {
        unit.Run('/', operand);
    }
}

class Divide : Command
{
    public Divide(ArithmeticUnit unit, double operand)
    {
        this.unit = unit;
        this.operand = operand;
    }
    public override void Execute()
    {
        unit.Run('/', operand);
    }
    public override void UnExecute()
    {
        unit.Run('*', operand);
    }
}

class Calculator
{
    ArithmeticUnit arithmeticUnit;
    ControlUnit controlUnit;
    public Calculator()
    {
        arithmeticUnit = new ArithmeticUnit();
        controlUnit = new ControlUnit();
    }
    private double Run(Command command)
    {
        controlUnit.StoreCommand(command);
        controlUnit.ExecuteCommand();
        return arithmeticUnit.Register;
    }

    public double Undo()
    {
        controlUnit.Undo();
        return arithmeticUnit.Register;
    }

    public double Redo()
    {
        controlUnit.Redo();
        return arithmeticUnit.Register;
    }

    public double Add(double operand)
    {
        return Run(new Add(arithmeticUnit, operand));
    }

    public double Substract(double operand)
    {
        return Run(new Substract(arithmeticUnit, operand));
    }

    public double Multiply(double operand)
    {
        return Run(new Multiply(arithmeticUnit, operand));
    }

    public double Divide(double operand)
    {
        return Run(new Divide(arithmeticUnit, operand));
    }

    

}

