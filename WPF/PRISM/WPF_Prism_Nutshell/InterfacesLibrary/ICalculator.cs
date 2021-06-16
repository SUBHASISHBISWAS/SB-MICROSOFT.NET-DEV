namespace WPFBasic_FirstPrismEx
{
    public interface ICalculator
    {
        int Add(Arguments args);
        int Sub(Arguments args);
        int Mul(Arguments args);
        int Div(Arguments args);
        int Execute(CommandTypes commandType, Arguments args);
    }
}