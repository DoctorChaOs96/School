namespace School.Services.Console
{
    public class ConsoleWrapper : IConsole
    {
        public void Clear()
        {
            System.Console.Clear();
        }

        public string? ReadLine()
        {
            return System.Console.ReadLine();
        }

        public void WriteLine(string? value)
        {
            System.Console.WriteLine(value);
        }
    }
}
