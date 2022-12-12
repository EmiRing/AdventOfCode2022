using System.Reflection.Metadata.Ecma335;

namespace AdventOFCode2022.TaskFiles
{
    public class Day7
    {
        private static readonly string[] Lines = File.ReadAllLines(@"C:\Emil\dev\AdventOfCode\AdventOFCode2022\InputData\Day7Input.txt");

        public static void Task1()
        {
            
            var currentDirectory = new Directory("/", null);
            
            foreach (var line in Lines)
            {
                var parts = line.Split(" ");

                if (parts[0] == "$" && parts[1] == "cd")
                {
                    if (parts[2] == "..")
                    {
                        currentDirectory = currentDirectory.TraverseUp(currentDirectory);
                    }
                    else if(parts[2] == "/")
                    {
                        currentDirectory = currentDirectory.TraverseRoot();
                    }
                    else
                    {
                        currentDirectory = currentDirectory.TraverseChild(parts[2]);
                    }
                }

                if (Int64.TryParse(parts[0], out long size))
                {
                    currentDirectory.AddFiles(parts[1], size);
                }

                if (parts[0] == "dir")
                {
                    currentDirectory.AddChild(parts[1], currentDirectory);
                }
            }

            currentDirectory = currentDirectory.TraverseRoot();

            
            long sum = 0;
            sum = currentDirectory.SumChosenValues(sum);

            var maxSpaceAvailable = 70000000;
            var neededForInstall = 30000000;
            long spaceAvailable = maxSpaceAvailable - neededForInstall;

            var neededToRemove = currentDirectory.TotalFileSize - spaceAvailable;

            var available = new Dictionary<string, long>();
            currentDirectory.FindFoldersBigEnough(available, neededToRemove);
            var toDelete = available.MinBy(x => x.Value);
            
            Console.WriteLine(sum);
            Console.WriteLine($"{toDelete.Key} : {toDelete.Value}");
        }
    }
    
    public class Directory
    {
        private long _limit = 100000;
        private long _sumFileSize = 0;
        public Directory? Parent { get; }
        
        public Directory(string name, Directory? parent)
        {
            Name = name;
            Parent = parent;
        }

        public string Name { get;}
        
        public List<Directory> Children { get; set; } = new();

        public void AddChild(string name, Directory? parent)
        {
            Children.Add(new Directory(name, parent));
        }

        public Dictionary<string, long> Files { get; } = new();

        public long TotalFileSize
        {
            get
            {
                var childrenSum = ChildrenFileSize(this);
                return _sumFileSize + childrenSum;
            }
            private set
            {
                _sumFileSize = value;
            }
        }

        private long ChildrenFileSize(Directory current)
        {
            long total = 0;
            foreach (var child in Children)
            {
                total += child.TotalFileSize;
            }

            return total;
        }

        public void AddFiles(string fileName, long fileSize)
        {
            Files.Add(fileName, fileSize);
            _sumFileSize += fileSize;
        }

        public Directory TraverseUp(Directory current)
        {
            if (current.Parent != null)
            {
                return current.Parent;
            }

            return this;
        }

        public Directory TraverseRoot()
        {
            var current = this;
            while (current.Parent != null)
            {
                current = TraverseUp(current);
            }

            return current;
        }

        public Directory TraverseChild(string name)
        {
            if (Children.Any(c => c.Name == name))
            {
                return Children.First(c => c.Name == name);
            }

            return this;
        }

        public void FindFoldersBigEnough(Dictionary<string, long> available, long missing)
        {
            if (TotalFileSize > missing)
            {
                available.Add(Name, TotalFileSize);
            }
            foreach (var child in Children)
            {
                child.FindFoldersBigEnough(available, missing);
            }
        }

        public long SumChosenValues(long sum)
        {
            if (TotalFileSize <= _limit) sum += TotalFileSize;
            foreach (var child in Children)
            {
                sum = child.SumChosenValues(sum);
            }

            return sum;
        }
    }
}