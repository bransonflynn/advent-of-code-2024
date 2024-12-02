using System.Linq;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Console.WriteLine("[Advent Of Code - Day 01]");

            int answerPart1 = Parts.Answer1();
            Console.WriteLine("Part 1 Answer: " + answerPart1);

            int answerPart2 = Parts.Answer2();
            Console.WriteLine("Part 2 Answer: " + answerPart2);

            watch.Stop();
            Console.WriteLine($"The Execution time of the program is {watch.ElapsedMilliseconds}ms");
        }
    }

    internal static class Parts
    {
        public static int Answer1()
        {
            int answer = 0;
            int[] listLeft = new int[1000];
            int[] listRight = new int[1000];
            var linesRead = File.ReadLines("input.txt");
            try
            {
                int index = 0;  // counter for within foreach loop
                foreach (var line in linesRead)
                {
                    string[] elems = line.Split("   ");
                    listLeft[index] = Convert.ToInt32(elems[0]);
                    listRight[index] = Convert.ToInt32(elems[1]);
                    index++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error reading input.txt");
                return -1;
            }

            Array.Sort(listLeft);
            Array.Sort(listRight);
            for (int i = 0; i < listLeft.Length; i++)
            {
                int difference = Math.Abs(listLeft[i] - listRight[i]);
                answer += difference;
            }

            return answer;
        }

        public static int Answer2()
        {
            int answer = 0;
            int[] listLeft = new int[1000];
            int[] listRight = new int[1000];
            var linesRead = File.ReadLines("input.txt");
            try
            {
                int index = 0;  // counter for within foreach loop
                foreach (var line in linesRead)
                {
                    string[] elems = line.Split("   ");
                    listLeft[index] = Convert.ToInt32(elems[0]);
                    listRight[index] = Convert.ToInt32(elems[1]);
                    index++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error reading input.txt");
                return -1;
            }

            var dictLeft = new Dictionary<int, int>();
            foreach (var num in listLeft)
            {
                if (dictLeft.ContainsKey(num))
                    dictLeft[num]++;
                else
                    dictLeft.TryAdd(num, 1);
            }

            var dictRight = new Dictionary<int, int>();
            foreach (var num in listRight)
            {
                if (dictRight.ContainsKey(num))
                    dictRight[num]++;
                else
                    dictRight.TryAdd(num, 1);
            }

            foreach (KeyValuePair<int, int> leftK in dictLeft)
            {
                if (dictRight.ContainsKey(leftK.Key))
                {
                    answer += leftK.Key * dictRight[leftK.Key]; // mult by rightCount
                }
            }
            return answer;
        }
    }
}
