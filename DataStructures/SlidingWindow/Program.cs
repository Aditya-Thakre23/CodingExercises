namespace SlidingWindow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Code Executor for SlidingWindow programs
            var arr = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            var k = 3;
            MaxInAllWindowsOfSizeK(arr, k);
        }

        static void MaxInAllWindowsOfSizeK(int[] arr, int k)
        {
            int i = 0, j = 0;
            var deque = new LinkedList<int>();
            deque.AddFirst(int.MinValue);

            while (j < arr.Length)
            {
                while (deque.Any() && deque.First.Value < arr[j])
                    deque.RemoveLast();
                deque.AddLast(arr[j]);

                if (j - i + 1 < k)
                    j++;
                else if (j - i + 1 == k)
                {
                    Console.WriteLine(deque.First.Value);

                    if (deque.First.Value == arr[i])
                        deque.RemoveFirst();

                    i++;
                    j++;
                }
            }
        }
    }
}