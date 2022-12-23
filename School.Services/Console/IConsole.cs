namespace School.Services.Console
{
    public interface IConsole
    {
        void WriteLine(string? value);

        string? ReadLine();

        void Clear();
    }
}
