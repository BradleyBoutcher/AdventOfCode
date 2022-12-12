using System.Text;

namespace AdventOfCode;

public class TwentyTwentyTwo : Year {
    public string Year
    {
        get => "2022";
        set { }
    }

    public async Task<int> Day_1()
    {
        var highestCalories = 0;
        var currentCalories = 0;
        var highestElf = 0;
        var currentElf = 0;
        
        var fileName = Utils.CreateFileName("1", "1", Year);
        var reader = new StreamReader(fileName);

        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
            if (line is null or "")
            {
                currentCalories = 0;
                currentElf++;
                continue;
            }

            currentCalories += int.Parse(line);
            if (currentCalories > highestCalories)
            {
                // Console.WriteLine(currentCalories);
                // Console.WriteLine(currentElf);
                highestCalories = currentCalories;
                highestElf = currentElf;
            }
        }

        return highestCalories;
    }

    public async Task<int> Day_1_PartTwo() 
    {
        var fileName = Utils.CreateFileName("1", "1", Year);
        var reader = new StreamReader(fileName);

        List<int> calorieTotals = new List<int>();
        var currentCalories = 0;

        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
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
            .Aggregate((x, y) => x + y);
    }

    public async Task<int> Day_2()
    {
        var fileName = Utils.CreateFileName("2", "1", Year);
        var reader = new StreamReader(fileName);

        int X = 1;
        int Y = 2;
        int Z = 3;

        int lose = 0;
        int tie = 3;
        int win = 6;

        int totalScore = 0;

        while (!reader.EndOfStream)
        {
            var line = (await reader.ReadLineAsync())?.Split();
            var opponent = line[0];
            var self = line[1];

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
        
        return totalScore;
    }

    public async Task<int> Day_2_PartTwo()
    {
        var fileName = Utils.CreateFileName("2", "1", Year);
        var reader = new StreamReader(fileName);

        int rock = 1;
        int paper = 2;
        int scissors = 3;

        int X = 0;
        int Y = 3;
        int Z = 6;

        int totalScore = 0;

        while (!reader.EndOfStream)
        {
            var line = (await reader.ReadLineAsync())?.Split();
            var opponent = line[0];
            var self = line[1];

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
        
        return totalScore;
    }

    public async Task<int> Day_3()
    {
        var fileName = Utils.CreateFileName("3", "1", Year);
        var reader = new StreamReader(fileName);

        var totalPriority = 0;
        while (!reader.EndOfStream)
        {
            var line = (await reader.ReadLineAsync())?.ToCharArray();
            
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

        return totalPriority;
    }

    public async Task<int> Day_3_PartTwo()
    {
        var fileName = Utils.CreateFileName("3", "1", Year);
        var reader = new StreamReader(fileName);

        var totalPriority = 0;
        while (!reader.EndOfStream)
        {
            var firstRucksack = (await reader.ReadLineAsync())?.ToCharArray();
            var secondRucksack = (await reader.ReadLineAsync())?.ToCharArray();
            var thirdRucksack = (await reader.ReadLineAsync())?.ToCharArray();

            var intersect = firstRucksack.Intersect(secondRucksack).Intersect(thirdRucksack);

            foreach (var c in intersect)
            {
                var index = char.IsUpper(c)
                    ? (c % 32) + 26
                    : c % 32;

                totalPriority += index;
            }
            
        }

        return totalPriority;
    }

    public async Task<int> Day_4()
    {
        var fileName = Utils.CreateFileName("4", "1", Year);
        var reader = new StreamReader(fileName);

        var completelyOverlappingSegments = 0;
        while (!reader.EndOfStream)
        {
            var assignments = (await reader.ReadLineAsync()).Split(',');

            var first = assignments[0].Split('-');
            var second = assignments[1].Split('-');

            var firstStart = int.Parse(first[0]);
            var firstEnd = int.Parse(first[1]);

            var secondStart = int.Parse(second[0]);
            var secondEnd = int.Parse(second[1]);

            if ((firstStart <= secondStart && firstEnd >= secondEnd) || (secondStart <= firstStart && secondEnd >= firstEnd)) {
                Console.WriteLine($"F{firstStart} - S{secondStart}, F{firstEnd} - S{secondEnd}");
                completelyOverlappingSegments++;
            }
        }

        return completelyOverlappingSegments;
    }

    public async Task<int> Day_4_Part2()
    {
        var fileName = Utils.CreateFileName("4", "1", Year);
        var reader = new StreamReader(fileName);

        var completelyOverlappingSegments = 0;
        while (!reader.EndOfStream)
        {
            var assignments = (await reader.ReadLineAsync()).Split(',');

            var first = assignments[0].Split('-');
            var second = assignments[1].Split('-');

            var firstStart = int.Parse(first[0]);
            var firstEnd = int.Parse(first[1]);

            var secondStart = int.Parse(second[0]);
            var secondEnd = int.Parse(second[1]);

            if ((firstStart <= secondStart && firstEnd >= secondEnd) || (secondStart <= firstStart && secondEnd >= firstEnd)) {
                Console.WriteLine($"F{firstStart} - S{secondStart}, F{firstEnd} - S{secondEnd}");
                completelyOverlappingSegments++;
            }
        }

        return completelyOverlappingSegments;
    }
}

