namespace AdventOFCode2022.TaskFiles;

public static class Day2
{
        private static string[] _lines = File.ReadAllLines(@"C:\Emil\dev\AdventOfCode\AdventOFCode2022\InputData\Day2Input.txt");

        public static void Task1()
        {
                var sum = 0;
                foreach (var line in _lines)
                {
                        switch (line)
                        {
                                case "A Y" or "B Z" or "C X":
                                        sum += 6;
                                        sum += GetValueForChoice(line[2]);
                                        break;
                                case "A X" or "B Y" or "C Z":
                                        sum += 3;
                                        sum += GetValueForChoice(line[2]);
                                        break;
                                case "A Z" or "B X" or "C Y":
                                        sum += 0;
                                        sum += GetValueForChoice(line[2]);
                                        break;
                        }
                }

                Console.WriteLine($"Task1: {sum}");

        }

        public static void Task2()
        {
                var sum = 0;
                foreach (var line in _lines)
                {
                        var temp = 0;
                        switch (line[2])
                        {
                                case 'Z':
                                        sum += 6;
                                        temp = (GetValueForChoice(line[0]) + 1);
                                        sum += temp > 3 ? temp % 3 : temp;
                                        break;
                                case 'Y':
                                        sum += 3;
                                        temp = GetValueForChoice(line[0]);
                                        sum += temp;
                                        break;
                                case 'X':
                                        sum += 0;
                                        temp = (GetValueForChoice(line[0]) -1);
                                        sum += temp < 1 ? 3 : temp;
                                        break;
                        }
                }
                
                Console.WriteLine($"Task2: {sum}");
        }

        public static int GetValueForChoice(char c)
        {
                return c switch
                {
                        'X' or 'A' => 1,
                        'Y' or 'B' => 2,
                        'Z' or 'C' => 3,
                        _ => 0
                };
        }
}

