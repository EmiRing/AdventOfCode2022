namespace AdventOFCode2022.TaskFiles
{
    public class Day3
    {
        private static string[] _lines = File.ReadAllLines(@"C:\Emil\dev\AdventOfCode\AdventOFCode2022\InputData\Day3Input.txt");

        public static void Task1()
        {
            var sum = 0;
            foreach (var line in _lines)
            {
                string firstCompartment = line.Substring(0, line.Length / 2);
                string secondCompartment = line.Substring(line.Length / 2);

                var match = firstCompartment.FirstOrDefault(c => secondCompartment.Contains(c));

                sum += ConvertToNumber(match);
                Console.WriteLine($"{sum}");
            }
        }

        public static void Task2()
        {
            var batches = _lines.Select((s, i) => _lines.Skip(i * 3).Take(3).ToList()).Where(a => a.Any()).ToList();

            var sum = 0;
            foreach (var batch in batches)
            {
                var match = batch[0].Where(c => batch[1].Contains(c)).ToList();
                var finalMatch = batch[2].FirstOrDefault(c => match.Contains(c));

                sum += ConvertToNumber(finalMatch);
                Console.WriteLine($"{sum}");
            }
        }
        
        private static int ConvertToNumber(char c)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return alphabet.IndexOf(c) + 1;
        }
    }
    
    
}