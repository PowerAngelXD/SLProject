namespace SLCore.Utils;

public static class SLOutput
{
    public static void Print(string? text, ConsoleColor? color = null)
    {
        if (!color.HasValue)
        {
            Console.WriteLine(text);
            return;
        }
        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color.Value;
        Console.WriteLine(text);
        Console.ForegroundColor = previousColor;
    }
}