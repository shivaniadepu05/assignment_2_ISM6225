using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            // This list will store the missing numbers
            List<int> result = new List<int>();

            // Using a HashSet for O(1) lookup time to track which numbers are present
            HashSet<int> seen = new HashSet<int>(nums);

            // Iterate from 1 to n (inclusive) to find which numbers are missing
            for (int i = 1; i <= nums.Length; i++)
            {
                if (!seen.Contains(i))
                {
                    result.Add(i); // Add the number if it's not found in the input array
                }
            }

            return result;
        }

        /*
        Edge Cases Handled:
        - Duplicate elements in input: e.g., [4,3,2,7,8,2,3,1] — handles duplicates by using a HashSet.
        - Empty array: returns an empty list as there are no elements to compare.
        - All numbers present: returns an empty list if nothing is missing.
        - Numbers out of expected range (1 to n): these are ignored by design since we check only 1 to nums.Length.
        */

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            // Create two separate lists for even and odd numbers
            List<int> even = new List<int>();
            List<int> odd = new List<int>();

            // Traverse through the input array and separate based on parity
            foreach (int num in nums)
            {
                if (num % 2 == 0)
                    even.Add(num); // Even numbers go first
                else
                    odd.Add(num);  // Odd numbers go after evens
            }

            // Append all odd numbers after even numbers
            even.AddRange(odd);

            // Convert the final list to an array and return
            return even.ToArray();
        }

        /*
        Edge Cases Handled:
        - All even numbers: the result will be the same as input, e.g., [2, 4, 6].
        - All odd numbers: result will also be same as input, just no evens at the beginning.
        - Mixed even and odd: correctly partitions and sorts parity as required.
        - Empty array: returns empty array without error.
        - Single element array: returns the same single element.
        */


        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            // Dictionary to store the number and its index
            Dictionary<int, int> map = new Dictionary<int, int>();

            // Traverse the array once
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                // If the complement exists in the dictionary, we found the pair
                if (map.ContainsKey(complement))
                    return new int[] { map[complement], i };

                // Store the current number and its index
                if (!map.ContainsKey(nums[i]))  // Avoid duplicate keys
                    map[nums[i]] = i;
            }

            // Return empty array if no pair is found
            return new int[0];
        }

        /*
        Edge Cases Handled:
        - Multiple pairs possible: returns the first valid pair found in one pass.
        - No valid pair: returns an empty array.
        - Duplicate elements: handled by checking index stored in map.
        - Array with negative numbers: works correctly with any integers.
        - Array with only two elements: returns correct indices if they sum to target.
        */


        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            // First, sort the array to easily access the largest and smallest numbers
            Array.Sort(nums);
            int n = nums.Length;

            // Two possible combinations:
            // 1. Product of the top 3 largest numbers (last three in sorted array)
            // 2. Product of two smallest (could be negative) and the largest number
            int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3];
            int product2 = nums[0] * nums[1] * nums[n - 1];

            // Return the maximum of the two
            return Math.Max(product1, product2);
        }

        /*
        Edge Cases Handled:
        - Array has negative numbers: handles by considering smallest two (can become large positive when multiplied).
        - All numbers are positive: returns product of three largest.
        - All numbers are negative: returns product of the three least negative (largest values).
        - Array with exactly three elements: works without error.
        - Large numbers: multiplication is safe as problem doesn't mention overflow concerns (if needed, use long).
        */


        

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Convert the given decimal number to binary using built-in method
                return Convert.ToString(decimalNumber, 2);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;

            // Use binary search to find the minimum in O(log n) time
            while (left < right)
            {
                int mid = (left + right) / 2;

                // If middle element is greater than the rightmost,
                // minimum must be in the right half
                if (nums[mid] > nums[right])
                    left = mid + 1;
                else
                    // Else, the minimum is in the left half (including mid)
                    right = mid;
            }

            // At the end, left == right, which is the index of the minimum element
            return nums[left];
        }

        /*
        Edge Cases Handled:
        - Fully sorted array (not rotated): still finds the minimum correctly.
        - Rotated at different positions: binary search locates the pivot accurately.
        - Array with 1 element: returns that single element safely.
        - Array with duplicates: this logic assumes no duplicates (as per standard LeetCode-style constraint).
        - Minimum is at the beginning or end: both are correctly handled.
        */


        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            // Negative numbers are never palindromes (e.g., -121 != 121-)
            if (x < 0) return false;

            // Convert the number to string to easily compare characters
            string s = x.ToString();

            // Use two-pointer approach to check if the string reads the same forwards and backwards
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }

        /*
        Edge Cases Handled:
        - Negative numbers: return false (not palindromes).
        - Single digit numbers (e.g., 7): always return true.
        - Numbers ending in 0 (except 0 itself): not palindromes.
        - Large palindromes like 12321 or 1001: works correctly.
        - Input = 0: returns true.
        */


        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {

            // Base case: F(0) = 0, F(1) = 1
            if (n <= 1)
                return n;

            // Initialize first two Fibonacci numbers
            int a = 0, b = 1, c = 0;

            // Loop to calculate Fibonacci numbers from F(2) to F(n)
            for (int i = 2; i <= n; i++)
            {
                c = a + b; // F(i) = F(i-1) + F(i-2)
                a = b;     // Move forward in the sequence
                b = c;
            }

            // Return the nth Fibonacci number
            return b;
        }
    }
}
