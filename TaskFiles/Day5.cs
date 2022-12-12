namespace AdventOFCode2022.TaskFiles
{
    public class Day5
    {
        private static readonly List<Stack<string>> Board = new()
        {
            new(new[]{"[F]" ,"[C]" ,"[J]" ,"[P]" ,"[H]" ,"[T]" ,"[W]"}),
            new(new[]{"[G]" ,"[R]" ,"[V]" ,"[F]" ,"[Z]" ,"[J]" ,"[B]" ,"[H]"}),
            new(new[]{"[H]" ,"[P]" ,"[T]" ,"[R]"}),
            new(new[]{"[Z]" ,"[S]" ,"[N]" ,"[P]" ,"[H]" ,"[T]"}),
            new(new[]{"[N]" ,"[V]" ,"[F]" ,"[Z]" ,"[H]" ,"[J]" ,"[C]" ,"[D]"}),
            new(new[]{"[P]" ,"[M]" ,"[G]" ,"[F]" ,"[W]" ,"[D]" ,"[Z]"}),
            new(new[]{"[M]" ,"[V]" ,"[Z]" ,"[W]" ,"[S]" ,"[J]" ,"[D]" ,"[P]"}),
            new(new[]{"[N]" ,"[D]" ,"[S]"}),
            new(new[]{"[D]" ,"[Z]" ,"[S]" ,"[F]" ,"[M]"}),
        };
        
        private static readonly string[] Lines = File.ReadAllLines(@"C:\Emil\dev\AdventOfCode\AdventOFCode2022\InputData\Day5Input.txt");
        
        public static void Task1()
        {
            foreach (var line in Lines)
            {
                string[] splitValues = line.Split(' ');
                var amount = int.Parse(splitValues[1]);
                var from = int.Parse(splitValues[3]);
                var to = int.Parse(splitValues[5]);
                ShuffleBoard(from, to, amount);
            }

            var answer = "";
            foreach (var row in Board)
            {
                answer += row.Peek();
            }

            Console.WriteLine(answer);
        }

        public static void Task2()
        {
            foreach (var line in Lines)
            {
                string[] splitValues = line.Split(' ');
                var amount = int.Parse(splitValues[1]);
                var from = int.Parse(splitValues[3]);
                var to = int.Parse(splitValues[5]);
                ShuffleOtherBoard(from, to, amount);
            }

            var answer = "";
            foreach (var row in Board)
            {
                answer += row.Peek();
            }

            Console.WriteLine(answer);
        }
        
        private static void ShuffleOtherBoard(int from, int to, int amount)
        {
            Stack<string> intermediate = new();
            for (var i = 0; i < amount; i++)
            {
                intermediate.Push(Board[from - 1].Pop());
            }
            
            for (var i = 0; i < amount; i++)
            {
                Board[to - 1].Push(intermediate.Pop());
            }
        }
        private static void ShuffleBoard(int from, int to, int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                Board[to - 1].Push(Board[from - 1].Pop());
            }
        }
    }
}