namespace SlidingWindow
{
    internal static class FixedSizeSlidingWindowProblems
    {
        /*
         * Identification:
            - Array/String question with something asked about subarray/substring.
            - Window size will be given(fixed size) or asked(variable size)
         * General Format
         i=0 //start of window
         j=0 //end of window
         while(j < arr.Length)
         {
            //Do some calculations
            
            //If the window size has not been hit then keep expanding
            if(j - i + 1 < k)
                j++;
            else if(j - i + 1 == k)
            {
                //Window size has been hit. Using the calculations done earlier, get an answer.
                //Now since we have the window size, we maintain this size and simply keep sliding. 
                
                //So we slide the window by 1. To do that, we remove the calculations done for element
                //arr[i].
                i++;
                j++;
            }
         }
         */
        internal static void MaxInAllSubArraysOfSizeK(int[] arr, int k)
        {
            int i = 0, j = 0;
            var deque = new LinkedList<int>();
            //To avoid getting a NullReferenceException
            deque.AddFirst(int.MinValue);

            while (j < arr.Length)
            {
                /*
                 For every element arr[j], all the elements to the left of it in the array, i.e the elements
                 that exist before it in the array and are lesser than it are useless to us as they can never
                 be a maximum in any subarray. So for the element arr[j], remove all the elements in the deque
                 that are lesser than it. The elements that are in the deque for any given element arr[j] are 
                 the ones that came before it. Since we are adding the elements at the rear of the deque, we can 
                 be sure of this fact. 
                 Finally add the element arr[j] to the rear of deque. 
                */
                while (deque.Any() && deque.First.Value < arr[j])
                    deque.RemoveLast();
                deque.AddLast(arr[j]);

                if (j - i + 1 < k)
                    j++;
                else if (j - i + 1 == k)
                {
                    /*
                     Window size has been hit. The maximum element for the current window will be at the front
                     of the deque since we only added an element if it was max as in we removed all the elements 
                     in the deque that were lesser than it. 
                    */
                    Console.WriteLine(deque.First.Value);

                    /*
                     We remove the calculations done for arr[i]. If arr[i] is a potential maximum then it will
                     be at the front of the deque. If it's not there that means it was one of the useless elements.
                     Hence the following check. So this is why we need a doubly-ended queue since insertion/deletion
                     has to be done at both the ends of the queue. 
                    */
                    if (deque.First.Value == arr[i])
                        deque.RemoveFirst();

                    i++;
                    j++;
                }
            }
        }

        internal static void CountOccurencesOfAnagram(string s, string pattern)
        {
            /*
             * Intuition:
            This is not a direct Sliding window problem but an example where sliding window works.
            Every anagram of a pattern will have the same length as the pattern and the occurrences of
            each of the characters in it will be same as the pattern string.
            So, we can maintain a sliding window of {size: pattern.Length} on string s and check if this 
            substring is an anagram of the pattern string.

             * How to check if window's substring is an anagram?
            - We maintain a lookup dictionary that stores the occurrences of each character in the pattern
            string. 
            - Then for every character s[j], if it is present in the dictionary, which means it is present in 
            the string, we decrement its count by 1.
            - Whenever the window size is hit, we simply check if the values for all the keys in the lookup
            dictionary is 0. If it is, then our substring is a valid anagram and we increment the answer.
             */
            var k = pattern.Length; //window size
            var lookup = new Dictionary<char, int>();
            int i = 0, j = 0;
            var ans = 0;

            //Populate the lookup with occurences of all characters in pattern string
            foreach (var ch in pattern)
            {
                if (!lookup.ContainsKey(ch))
                    lookup[ch] = 0;
                lookup[ch]++;
            }

            while (j < s.Length)
            {
                if (lookup.ContainsKey(s[j]))
                {
                    lookup[s[j]]--;
                }

                if (j - i + 1 < k)
                    j++;
                else if (j - i + 1 == k)
                {
                    var isLookupEmpty = lookup.Values.All(x => x == 0);
                    if (isLookupEmpty)
                        ans++;

                    if (lookup.ContainsKey(s[i]))
                        lookup[s[i]]++;
                    i++;
                    j++;
                }
            }
            Console.WriteLine(ans);
        }

        internal static void FirstNegativeInEveryWindowOfSizeK(int[] arr, int k)
        {
            /*
             * Intuition: The only issue with this problem is that we have to keep track of all the negative integers,
             since once we remove a negative integer, we need to get the next negative integer. To do this,
             we use a queue, since it's a FIFO data structure. We keep adding the negative integers to the 
             queue so that the order is maintained. 
             Then whenever we slide the window, if the element is currently at the front, i.e it was the first negative,
             we dequeue it and the next negative element for the current window should now be available at the front of 
             the queue.
            */
            int i = 0, j = 0;
            var queue = new Queue<int>();
            while (j < arr.Length)
            {
                if (arr[j] < 0)
                    queue.Enqueue(arr[j]);

                if (j - i + 1 < k)
                    j++;
                else if (j - i + 1 == k)
                {
                    if (queue.Count != 0)
                        Console.WriteLine(queue.Peek());
                    else
                        Console.WriteLine(0);
                    if (queue.Any() && queue.First() == arr[i])
                        queue.Dequeue();
                    i++;
                    j++;
                }
            }
        }

        internal static void MaxSumSubarrayofSizeK(int[] arr, int k)
        {
            int i = 0, j = 0;
            int ans = int.MinValue, sum = 0;

            while (j < arr.Length)
            {
                sum += arr[j];

                if (j - i + 1 < k)
                    j++;
                else if (j - i + 1 == k)
                {
                    ans = Math.Max(ans, sum);

                    sum -= arr[i];
                    i++;
                    j++;
                }
            }
            Console.WriteLine(ans);
        }
    }
}
