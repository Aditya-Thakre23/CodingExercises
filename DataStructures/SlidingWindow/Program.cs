namespace SlidingWindow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Code Executor for SlidingWindow programs
            FixedSizeSWProblems();
        }

        static void FixedSizeSWProblems()
        {
            var arr = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            var k = 3;
            string s = "forxxorfxdofr";
            string pattern = "for";
            Console.WriteLine("*****Fixed-size sliding window problems*****");
            Console.WriteLine("List of inputs: \narr: ");
            foreach (var i in arr)
                Console.Write(i + " ");
            Console.WriteLine("\nk: " + k);
            Console.WriteLine("Problem 1: Maximum sum for all subarrays of size k");
            Console.WriteLine("Output: ");
            FixedSizeSlidingWindowProblems.MaxSumSubarrayofSizeK(arr, k);

            Console.WriteLine("Problem 2: First negative element in each subarray of size k");
            Console.WriteLine("Output: ");
            FixedSizeSlidingWindowProblems.FirstNegativeInEveryWindowOfSizeK(arr, k);

            Console.WriteLine("Problem 3: Maximum element in each subarray of size k");
            Console.WriteLine("Output: ");
            FixedSizeSlidingWindowProblems.MaxInAllSubArraysOfSizeK(arr, k);

            Console.WriteLine("Problem 4(Misc): Count occurrences of anagrams of a given pattern in a string.");
            Console.WriteLine($"List of inputs: \ns: {s} \npattern: {pattern}");
            Console.WriteLine("Output: ");
            FixedSizeSlidingWindowProblems.CountOccurencesOfAnagram(s, pattern);
        }
    }
}