namespace AdventOfCode
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void WriteLine(string value)
            => Console.WriteLine(value);
    }
}
