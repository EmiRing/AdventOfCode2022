namespace AdventOFCode2022.TaskFiles;

public class Day1
{
    private static string[] _lines = File.ReadAllLines(@"C:\Emil\dev\AdventOfCode\AdventOFCode2022\InputData\Day1Input.txt");

    public static void Task1()
    {
        
        var elves = new Dictionary<int, int>();
        var elfNumber = 1;

        var sum = 0;
        foreach (var line in _lines)
        {
            if (line == string.Empty)
            {
                elves.Add(elfNumber++, sum);
                sum = 0;
                continue;
            }

            sum += int.Parse(line);
        }

        if (sum != 0)
        {
            elves.Add(elfNumber, sum);
        }


        foreach (var elf in elves)
        {
            Console.WriteLine($"{elf.Key}: {elf.Value}");
        }

        var mostCalories = elves.MaxBy(e => e.Value);

        Console.WriteLine(mostCalories);
        
        Task2(elves);
    }

    public static void Task2(Dictionary<int, int> elves)
    {
        var threeMostCalories = elves.OrderByDescending(e => e.Value).Take(3).Sum(s => s.Value);

        Console.WriteLine(threeMostCalories);
    }
}   
