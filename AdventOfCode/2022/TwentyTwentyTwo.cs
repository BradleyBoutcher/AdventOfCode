using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdventOfCode._2022;

public class TwentyTwentyTwo : Year {
    public string Year
    {
        get => "2022";
        set { }
    }

    // Method names must start with "Day_X"
    public async Task<string> Template_1(string input)
    {
        var result = "";

        return result;
    }

    public async Task<string> Day_1(string input)
    {
        return input
            .Split("\n\n")
            .Select(s => s.Split())
            .Select(s => s
                .Select(Int32.Parse)
                .Sum())
            .Max()
            .ToString();
    }

    public async Task<string> Day_1_PartTwo(string input)
    {
        var lines = input.Split("\n");

        List<int> calorieTotals = new List<int>();
        var currentCalories = 0;

        foreach (var line in lines)
        {
            if (line is null or "")
            {
                calorieTotals.Add(currentCalories);
                currentCalories = 0;
                continue;
            }

            currentCalories += int.Parse(line);
        }

        return calorieTotals
            .OrderByDescending(c => c)
            .Take(3)
            .Aggregate((x, y) => x + y)
            .ToString();
    }

    public async Task<string> Day_2(string input)
    {
        var lines = input.Split("\n");

        int X = 1;
        int Y = 2;
        int Z = 3;

        int lose = 0;
        int tie = 3;
        int win = 6;

        int totalScore = 0;

        foreach (var line in lines)
        {
            var opponent = line[0].ToString();
            var self = line[2].ToString();

            switch (opponent, self)
            {
                case ("A", "X"): totalScore += (X + tie);
                    break;
                case ("A", "Y"): totalScore += (Y + win);
                    break;
                case ("A", "Z"): totalScore += (Z + lose);
                    break;

                case ("B", "X"): totalScore += (X + lose);
                    break;
                case ("B", "Y"): totalScore += (Y + tie);
                    break;
                case ("B", "Z"): totalScore += (Z + win);
                    break;
                
                case ("C", "X"): totalScore += (X + win);
                    break;
                case ("C", "Y"): totalScore += (Y + lose);
                    break;
                case ("C", "Z"): totalScore += (Z + tie);
                    break;
            }
        }
        
        return totalScore.ToString();
    }

    public async Task<string> Day_2_PartTwo(string input)
    {
        var lines = input.Split("\n");

        int rock = 1;
        int paper = 2;
        int scissors = 3;

        int X = 0;
        int Y = 3;
        int Z = 6;

        int totalScore = 0;

        foreach (var line in lines)
        {
            var opponent = line[0].ToString();
            var self = line[2].ToString();

            switch (opponent, self)
            {
                case ("A", "X"): totalScore += (X + scissors);
                    break;
                case ("A", "Y"): totalScore += (Y + rock);
                    break;
                case ("A", "Z"): totalScore += (Z + paper);
                    break;

                case ("B", "X"): totalScore += (X + rock);
                    break;
                case ("B", "Y"): totalScore += (Y + paper);
                    break;
                case ("B", "Z"): totalScore += (Z + scissors);
                    break;
                
                case ("C", "X"): totalScore += (X + paper);
                    break;
                case ("C", "Y"): totalScore += (Y + scissors);
                    break;
                case ("C", "Z"): totalScore += (Z + rock);
                    break;
            }
        }
        
        return totalScore.ToString();
    }

    public async Task<string> Day_3(string input)
    {
        var lines = input.Split("\n");

        var totalPriority = 0;
        foreach (var item in lines)
        {
            var line = item.ToCharArray();
            
            var firstCompartment = line.Take(line.Length / 2).ToArray();
            var secondCompartment = line.Skip(line.Length / 2).ToArray();

            var intersect = firstCompartment.Intersect(secondCompartment);

            foreach (var c in intersect)
            {
                var index = char.IsUpper(c)
                    ? (c % 32) + 26
                    : c % 32;

                totalPriority += index;
            }
        }

        return totalPriority.ToString();
    }

    public async Task<string> Day_3_PartTwo(string input)
    {
        var lines = input.Split("\n");

        var totalPriority = 0;
        for (int i = 0; i < lines.Length; i+=3)
        {
            var firstRucksack = lines[i].ToCharArray();
            var secondRucksack = lines[i+1].ToCharArray();
            var thirdRucksack = lines[i+2].ToCharArray();

            var intersect = firstRucksack
                .Intersect(secondRucksack)
                .Intersect(thirdRucksack);

            foreach (var c in intersect)
            {
                var index = char.IsUpper(c)
                    ? (c % 32) + 26
                    : c % 32;

                totalPriority += index;
            }
            
        }

        return totalPriority.ToString();
    }

    public async Task<string> Day_4(string input)
    {
        var lines = input.Split("\n");

        var completelyOverlappingSegments = 0;
        foreach (var line in lines)
        {
            var assignments = line.Split(',');

            var first = assignments[0].Split('-');
            var second = assignments[1].Split('-');

            var firstStart = int.Parse(first[0]);
            var firstEnd = int.Parse(first[1]);

            var secondStart = int.Parse(second[0]);
            var secondEnd = int.Parse(second[1]);

            if ((firstStart <= secondStart && firstEnd >= secondEnd) || (secondStart <= firstStart && secondEnd >= firstEnd)) {
                completelyOverlappingSegments++;
            }
        }

        return completelyOverlappingSegments.ToString();
    }

    public async Task<string> Day_4_Part_2(string input)
    {
        var lines = input.Split("\n");

        var overlappingSegments = 0;
        foreach (var line in lines)
        {
            var assignments = line.Split(',');

            var first = assignments[0].Split('-');
            var second = assignments[1].Split('-');

            var firstStart = int.Parse(first[0]);
            var firstEnd = int.Parse(first[1]);

            var secondStart = int.Parse(second[0]);
            var secondEnd = int.Parse(second[1]);

            if ((firstStart <= secondStart && firstEnd >= secondStart) || (secondStart <= firstStart && secondEnd >= firstStart)) {
                overlappingSegments++;
            }
        }

        return overlappingSegments.ToString();
    }

    public async Task<string> Day_5(string input)
    {
        var crates = new[,]
        {
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "T", "V", "", "", "", "", "", "W", "" },
            { "V", "C", "P", "D", "", "", "", "B", "" },
            { "J", "P", "R", "N", "B", "", "", "Z", "" },
            { "W", "Q", "D", "M", "T", "", "L", "T", "" },
            { "N", "J", "H", "B", "P", "T", "P", "L", "" },
            { "R", "D", "F", "P", "R", "P", "R", "S", "G" },
            { "M", "W", "J", "R", "V", "B", "J", "C", "S" },
            { "S", "B", "B", "F", "H", "C", "B", "N", "L" },
            { "0", "0", "0", "0", "0", "0", "0", "0", "0" }
        };
        var height = crates.Length;

        var lines = input.Split("\n");

        foreach (var line in lines)
        {
            var command = line.Split(" ");

            var toMove = int.Parse(command[1]);
            var from = int.Parse(command[3]) - 1;
            var to = int.Parse(command[5]) - 1;

            while (toMove > 0)
            {
                var grabbed = "";
                var emptyRowCoordinate = -1;

                for (var row = 0; row < height; row++)
                {
                    var crate = crates[row, from];
                    var space = crates[row, to];

                    // drop off a crate
                    if (space != "" && grabbed != "")
                    {
                        crates[emptyRowCoordinate, to] = grabbed;
                        toMove--;
                        break;
                    }

                    // check for crate to grab
                    if (grabbed == "" && crate != "")
                    {
                        grabbed = crate;
                        crates[row, from] = "";
                    }

                    // check for lower empty space
                    if (space == "" && row > emptyRowCoordinate)
                    {
                        emptyRowCoordinate = row;
                    }
                }
            }
        }

        string answer = "";

        for (int i = 0; i < 9; i++)
        {
            int d = 0;
            while (crates[d, i] == "") d++;
            answer += crates[d, i];
        }

        return answer;
    }

    public async Task<string> Day_5_Part2(string input)
    {
        var crates = new[,]
        {
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "T", "V", "", "", "", "", "", "W", "" },
            { "V", "C", "P", "D", "", "", "", "B", "" },
            { "J", "P", "R", "N", "B", "", "", "Z", "" },
            { "W", "Q", "D", "M", "T", "", "L", "T", "" },
            { "N", "J", "H", "B", "P", "T", "P", "L", "" },
            { "R", "D", "F", "P", "R", "P", "R", "S", "G" },
            { "M", "W", "J", "R", "V", "B", "J", "C", "S" },
            { "S", "B", "B", "F", "H", "C", "B", "N", "L" },
            { "0", "0", "0", "0", "0", "0", "0", "0", "0" }
        };
        var height = crates.Length;

        var lines = input.Split("\n");

        foreach (var line in lines)
        {
            var command = line.Split(" ");

            var toMove = int.Parse(command[1]);
            var from = int.Parse(command[3]) - 1;
            var to = int.Parse(command[5]) - 1;

            var grabbed = new Stack<string>();
            var bottom = -1;

            for (var row = 0; row < height; row++)
            {
                if (crates[row, from] == "") continue;

                grabbed.Push(crates[row, from]);
                crates[row, from] = "";

                if (grabbed.Count == toMove) break;
            }

            for (var row = 0; row < height; row++)
            {
                if (crates[row, to] == "") continue;

                bottom = row - 1;
                break;
            }

            while (grabbed.Any())
            {
                crates[bottom, to] = grabbed.Pop();
                bottom--;
            }
        }

        string answer = "";

        for (int i = 0; i < 9; i++)
        {
            int d = 0;
            while (crates[d, i] == "") d++;
            answer += crates[d, i];
        }

        return answer;
    }

    public async Task<string> Day_6(string input)
    {
        var visited = new HashSet<char>();

        for (int i = 0; i < input.Length; i++)
        {
            visited.Clear();

            var noCollision =
                visited.Add(input[i]) &&
                visited.Add(input[i + 1]) &&
                visited.Add(input[i + 2]) &&
                visited.Add(input[i + 3]);
 
            if (noCollision) return (i + 4).ToString();
        }

        return 0.ToString();
    }

    public async Task<string> Day_6_Part_2(string input)
    {
        var visited = new HashSet<char>();

        for (int i = 0; i < input.Length; i++)
        {
            visited.Clear();
            
            var noCollision = true;
            
            for (int j = 0; j < 14; j++)
            {
                noCollision = visited.Add(input[i + j]);
                if (!noCollision) break;
            }

            if (noCollision) return (i + 14).ToString();
        }

        return 0.ToString();
    }

    public async Task<string> Day_7(string input)
    {
        var commands = input.Split("\n");

        var tree = new Stack<string>();
        var directories = new Dictionary<string, int>();

        foreach (var command in commands)
        {
            var pieces = command.Split(" ");

            if (pieces[0] == "$")
            {
                if (pieces[1] != "cd") continue;

                if (pieces[2] == ".." && tree.Count > 0) tree.Pop();
                else tree.Push(pieces[2]);
            }
            else if (pieces[0] != "dir")
            {
                // this entry is a file size
                var size = Int32.Parse(pieces[0]);
                // add the file size to each parent's dictionary entry
                foreach (var s in tree)
                {
                    var exists = directories.TryGetValue(s, out _);
                    if (exists) directories[s] += size;
                    else directories.Add(s, size);
                }
            }
        }

        var total = directories.Values.Where(s => s < 100000).Sum();
        return total.ToString();
    }

    public async Task<string> Day_13(string input)
    {
        var index = 0;
        var total = 0;

        var groups = input.Split("\n\n");
        foreach (var group in groups)
        {
            index++;
            var segment = group.Split("\n");

            var rawFirstLine = segment[0];
            var rawSecondLine = segment[1];

            var firstRoot = JsonDocument.Parse(rawFirstLine).RootElement;
            var secondRoot = JsonDocument.Parse(rawSecondLine).RootElement;

            if (Compare(firstRoot, secondRoot) < 0) total += index;
        };

        return total.ToString();
    }

    public async Task<string> Day_13_Part_2(string input)
    {
        var index = 0;
        var total = 0;

        var packets = input
            .Split("\n\n")
            .Select(pair => pair.Split("\n"))
            .Select(pair => (Left: JsonDocument.Parse(pair[0]).RootElement, Right: JsonDocument.Parse(pair[1]).RootElement))
            .SelectMany(pair => new [] {pair.Left, pair.Right})
            .Append(JsonDocument.Parse("[[2]]").RootElement)
            .Append(JsonDocument.Parse("[[6]]").RootElement)
            .OrderBy(packet => packet, Comparer<JsonElement>.Create((l, r) => Compare(l, r)));

        var divider1 = packets
            .Select((packet, index) => (Packet: packet, Index: index + 1))
            .First(item => Compare(item.Packet, JsonDocument.Parse("[[2]]").RootElement) == 0).Index;

        var divider2 = packets
            .Select((packet, index) => (Packet: packet, Index: index + 1))
            .First(item => Compare(item.Packet, JsonDocument.Parse("[[6]]").RootElement) == 0).Index;

        return (divider1 * divider2).ToString();
    }

    private int Compare(JsonElement left, JsonElement right)
    {
        if (left.ValueKind == JsonValueKind.Number && right.ValueKind == JsonValueKind.Number)
        {
            return left.GetInt32() - right.GetInt32();
        } 
        if (left.ValueKind == JsonValueKind.Number)
        {
            return Compare(JsonDocument.Parse($"[{left.GetInt32()}]").RootElement, right);
        } 
        if (right.ValueKind == JsonValueKind.Number)
        {
            return Compare(left, JsonDocument.Parse($"[{right.GetInt32()}]").RootElement);
        }

        foreach (var (nextLeft, nextRight) in Enumerable.Zip(left.EnumerateArray(), right.EnumerateArray()))
        {
            var current = Compare(nextLeft, nextRight);
            if (current == 0)
            {
                continue;
            }

            return current;
        }

        return left.GetArrayLength() - right.GetArrayLength();
    }

}

