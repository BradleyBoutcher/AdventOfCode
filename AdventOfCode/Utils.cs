using System.Reflection;

namespace AdventOfCode;

public static class Utils
{
    public static string CreateFileName(string day, string puzzle, string year)
    {
        return "/Users/b.boutcher/RiderProjects/AdventOfCode/AdventOfCode/" + year + "/" + day + "." + puzzle + ".txt";
    }

    public static async Task RunAllDays(Year year) {
        Console.WriteLine($"~~~ Advent Of Code {year.Year} ~~~");
        Console.WriteLine();

        var methods = year
            .GetType()
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(item => item.Name.StartsWith("Day"));

        foreach (var method in methods)
        {
            int output = await (Task<int>) method.Invoke(year, new Object[0]);
            Console.WriteLine($"-- Output for {method.Name} --");
            Console.WriteLine($"Answer: {output}");
            Console.WriteLine();
        }
    }  
}
