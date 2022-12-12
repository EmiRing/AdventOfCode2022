namespace AdventOFCode2022.TaskFiles
{
    public class Day4
    {
        private static readonly string[] _lines = File.ReadAllLines(@"C:\Emil\dev\AdventOfCode\AdventOFCode2022\InputData\Day4Input.txt");

        public static void Task1()
        {
            var count = 0;
            foreach (var line in _lines)
            {
                string[] elves =  line.Split('-', ',');
                int[] assignments = Array.ConvertAll(elves, s => Int32.Parse(s));
                
                if (assignments[2] <= assignments[1] && assignments[2] >= assignments[0] && assignments[3] <= assignments[1] )
                {
                    count++;
                }

                else if (assignments[0] <= assignments[3] && assignments[0] >= assignments[2] && assignments[1] <= assignments[3])
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
        
        public static void Task2()
        {
            var count = 0;
            foreach (var line in _lines)
            {
                string[] strings =  line.Split('-', ',');
                int[] assignments = Array.ConvertAll(strings, s => Int32.Parse(s));
                
                if (assignments[2] <= assignments[1] && assignments[2] >= assignments[0])
                {
                    count++;
                }

                else if (assignments[0] <= assignments[3] && assignments[0] >= assignments[2])
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}