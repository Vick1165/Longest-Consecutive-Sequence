using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Consecutive_Sequence
{
    //https://leetcode.com/problems/longest-consecutive-sequence/

    //Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
    //You must write an algorithm that runs in O(n) time.
    public class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 100, 4, 200, 1, 3, 2 };
            var ouput = LongestConsecutive(input);
            var output_ON = LongestConsecutive1(input);
            Console.WriteLine(ouput);
            Console.WriteLine(output_ON);
        }

        //O(N)
        public static int LongestConsecutive1(int[] nums)
        {
            var size = nums.Length;
            var max = 0;
            HashSet<int> set = new HashSet<int>(nums);

            for (int i = 0; i < size; i++)
            {
                int current_num = nums[i];
                int currentSequence = 1;

                // this if condition improves performance. we are checking starting point for ex : current_num = 2 and 
                // nums array contains 1 then no need to check for sequence starting from 2 we can skip it. 
                // this will allows us to only search from starting point of continous sequence.
                // [1,2,3,4] [100]  [200]
                if (!set.Contains(current_num - 1))
                {
                    while (set.Contains(current_num + 1))
                    {
                        current_num++;
                        currentSequence++;
                    }
                }

                max = Math.Max(max, currentSequence);

            }
            return max;
        }

        //O(N^3)
        public static int LongestConsecutive(int[] nums)
        {
            var size = nums.Length;
            var max = 0;
            for (int i = 0; i < size; i++)
            {
                int current_num = nums[i];
                int currentSequence = 1;

                while (IsNextConsecutiveNumberExists(nums,current_num + 1))
                {
                    current_num++;
                    currentSequence++;
                }

                max = Math.Max(max, currentSequence);

            }
            return max;
        }

        private static bool IsNextConsecutiveNumberExists(int[] nums, int j)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == j)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
