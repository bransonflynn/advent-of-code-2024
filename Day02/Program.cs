namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Advent Of Code - Day 02]");

            int answer1 = Part.Answer1();
            Console.WriteLine("Part 1 Answer: " + answer1);
        }
    }

    internal static class Part
    {
        public static int Answer1()
        {
            int safeReports = 0;
            var linesRead = File.ReadLines("input.txt");
            foreach (var line in linesRead)
            {
                string[] elemsStr = line.Split(" ");
                Console.WriteLine("elemstr done");
                int[] elems = Array.ConvertAll(elemsStr, int.Parse);
                Console.WriteLine("convert done");
                if (IsSafe(elems))
                {
                    safeReports++;
                }
            }

            return safeReports;
        }

        public static bool IsSafe(int[] arr)
        {
            if (IsArrayIncreasingOrDecreasing(arr) && IsChangeRateValid(arr))
                return true;
            else
                return false;
        }
        public static bool IsArrayIncreasingOrDecreasing(int[] arr)
        {
            // todo/note - this might not work if reports can increase+decrease levels in the same report
            // int len = arr.Length;
            // if (arr[0] <= arr[1] && arr[len - 2] <= arr[len - 1])
            //     return true;
            // else if (arr[0] >= arr[1] && arr[len - 2] >= arr[len - 1])
            //     return true;
            // else
            //     return false;


            // -1 = unset, 0 = decreasing, 1 = increasing
            int mode;
            if (arr[0] > arr[1])
            {
                // decreasing
                mode = 0;
            }
            else if (arr[0] < arr[1])
            {
                // increasing
                mode = 1;
            }
            else
            {
                // no change, return false early
                return false;
            }

            for (int i = 0; i < arr.Length - 1; i++) { }

            return false;
        }

        public static bool IsChangeRateValid(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (Math.Abs(arr[i] - arr[i + 1]) < 1 && Math.Abs(arr[i] - arr[i + 1]) > 3)
                {
                    return false;
                }
                i++;
            }
            return true;
        }
    }
}
