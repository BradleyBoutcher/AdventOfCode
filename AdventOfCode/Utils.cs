using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

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

        var times = new Dictionary<string, long>();
        foreach (var method in methods)
        {
            var fileName = CreateFileName(method.Name.Split('_')[1], "1", year.Year);
            var file = await new StreamReader(fileName).ReadToEndAsync();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var output = await (Task<string>) method.Invoke(year, new []{ file });
            stopwatch.Stop();
            Console.WriteLine($"-- Output for {method.Name} --");
            Console.WriteLine($"Answer: {output}");
            Console.WriteLine();
            times.Add(method.Name, stopwatch.ElapsedMilliseconds);
        }

        Console.WriteLine("Elapsed Time in MS");
        foreach (var (key, value) in times)
        {
            Console.WriteLine(key + ": " + value + "ms");
        }
    }  

    public static void Print2DArray<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public static StreamReader NewPuzzleReader(string year, [CallerMemberName] string callingMember = null, string puzzle = "1")
    {
        var rawDay = callingMember.Split("_")[1];
        var fileName = CreateFileName(rawDay, puzzle, year);
        return new StreamReader(fileName);
    }
}
