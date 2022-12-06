namespace AdventOFCode2022.Day6
{
    public class Day6
    {
        private static readonly string Text =
            File.ReadAllText(@"C:\Emil\dev\AdventOfCode\AdventOFCode2022\InputData\Day6Input.txt");

        public static void Task(int init)
        {
            int stringLength = Text.Length;
            var counter = init;

            while (counter < stringLength)
            {
                var evaluatedString = Text.Substring(counter - init, init);
                var count = evaluatedString.Distinct().Count();
                if (count == init)
                {
                    Console.WriteLine(counter);
                    break;
                }
                counter++;
            }

            if (counter == stringLength)
            {
                Console.WriteLine("Could not find a start-of-message of that length");
            }
        }
    }
}
