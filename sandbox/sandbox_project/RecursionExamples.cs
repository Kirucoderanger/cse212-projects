using System.Collections.Generic;
using System;


// Example usage of recursion examples
public class RecursionExamples
{
    public static void Run()
    {
        Console.WriteLine("Recursion Examples:");

        int number = 5;
        int factorialResult = Factorial(number);
        Console.WriteLine($"Factorial of {number} is {factorialResult}");

        int fibIndex = 6;
        int fibonacciResult = Fibonacci(fibIndex);
        Console.WriteLine($"Fibonacci number at index {fibIndex} is {fibonacciResult}");

        int fibMemoIndex = 90;
        long fibonacciMemoResult = FibonacciMemo(fibMemoIndex);
        Console.WriteLine($"Fibonacci number at index {fibMemoIndex} with memoization is {fibonacciMemoResult}");

        string str = "abc";
        Console.WriteLine($"Permutations of '{str}':");
        Permutations(str);

        int[] sortedArray = { 1, 3, 5, 7, 9, 11 };
        int target = 7;
        int searchResult = BinarySearch(sortedArray, target, 0, sortedArray.Length - 1);
        Console.WriteLine($"Binary search for {target} in sorted array: Index {searchResult}");


        Console.WriteLine(BinarySearch2(new[]{1, 3, 6, 18, 20, 25, 34, 38, 89, 95, 99, 100}, 89)); // true
        Console.WriteLine(BinarySearch2(new[]{1, 3, 6, 18, 20, 25, 34, 38, 89, 95, 99, 100}, 1));  // true
        Console.WriteLine(BinarySearch2(new[]{1, 3, 6, 18, 20, 25, 34, 38, 89, 95, 99, 100}, 17)); // false

        int[] arrayToSum = { 1, 2, 3, 4, 5 };
        int sumResult = SumArray(arrayToSum, arrayToSum.Length);
        Console.WriteLine($"Sum of array elements is {sumResult}");
        int n = 10;
        int sumToNResult = SumToN(n);
        Console.WriteLine($"Sum from 1 to {n} is {sumToNResult}");
    }

    // Recursive method to calculate factorial
    // the performance is O(n) because there are n recursive calls made before reaching the base case.
    public static int Factorial(int n)
    {
        if (n <= 1)
            return 1; // Base case
        return n * Factorial(n - 1);
    }

    // Recursive method to calculate Fibonacci number
    // the performance is O(2^n) because each call to Fibonacci(n)
    // results in two additional calls to Fibonacci(n-1) and Fibonacci(n-2)
    public static int Fibonacci(int n)
    {
        if (n <= 0)
            return 0;
        if (n == 1)
            return 1;
        if (n == 2)
            return 1;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }


    //Memoization version of Fibonacci
    // the performance is O(n) because each Fibonacci number is computed only once and stored for future reference.
    /*public static int FibonacciMemo(int n, Dictionary<int, int> memo = null)
    {
        if (memo == null)
            memo = new Dictionary<int, int>();

        if (memo.ContainsKey(n))
            return memo[n];

        if (n <= 0)
            return 0;
        if (n == 1 || n == 2)
            return 1;

        int result = FibonacciMemo(n - 1, memo) + FibonacciMemo(n - 2, memo);
        memo[n] = result;
        return result;
    }*/

    public static long FibonacciMemo(int n, Dictionary<int, long> memo = null)
    {
        // Initialize memoization dictionary on first call
        if (memo == null)
            memo = new Dictionary<int, long>();
        // base cases
        if (n <= 0)
            return 0;
        if (n == 1 || n == 2)
            return 1;
        // check if result is already computed
        if (memo.ContainsKey(n))
            return memo[n];
        // compute result and store in memoization dictionary
        var result = FibonacciMemo(n - 1, memo) + FibonacciMemo(n - 2, memo);
        // store the computed result in the dictionary
        memo[n] = result;
        return result;

    }

    // Permutation using recursion
    // the performance is O(n!), because the number of permutations of a string of length n is n!
    /*public static List<string> GetPermutations(string str)
    {
        var result = new List<string>();
        if (str.Length == 1)
        {
            result.Add(str);
            return result;
        }

        for (int i = 0; i < str.Length; i++)
        {
            char currentChar = str[i];
            string remainingChars = str.Substring(0, i) + str.Substring(i + 1);
            foreach (var perm in GetPermutations(remainingChars))
            {
                result.Add(currentChar + perm);
            }
        }
        return result;
    }*/

    public static void Permutations(string letters, string word = "")
    {
        // Try adding each of the available letters
        // to the 'word' and add up all the
        // resulting permutations.
        if (letters.Length == 0)
        {
            Console.WriteLine(word);
        }
        else
        {
            for (var i = 0; i < letters.Length; i++)
            {
                // Make a copy of the letters to pass to the
                // the next call to permutations.  We need
                // to remove the letter we just added before
                // we call permutations again.
                var lettersLeft = letters.Remove(i, 1);

                // Add the new letter to the word we have so far
                Permutations(lettersLeft, word + letters[i]);
            }
        }
    }

    // Recursion for Binary Search
    // the performance is O(log n) because with each recursive call,
    // the size of the search space is halved.
    public static int BinarySearch(int[] arr, int target, int low, int high)
    {
        if (low > high)
            return -1; // Element not found

        int mid = low + (high - low) / 2;

        if (arr[mid] == target)
            return mid; // Element found at mid index

        if (arr[mid] > target)
            return BinarySearch(arr, target, low, mid - 1); // Search in left half
        else
            return BinarySearch(arr, target, mid + 1, high); // Search in right half
    }

    
public static bool BinarySearch2(int[] sortedArray, int target)
{
    if (sortedArray.Length == 1)
    {
        // Base case
        return target == sortedArray[0];
    }
    else
    {
        // Find the middle and compare
        var middle = sortedArray.Length / 2;

        if (target == sortedArray[middle])
        {
            // We got lucky and the middle was the match
            return true;
        }
        else if (target < sortedArray[middle])
        {
            // Search the first half (index 0 to middle-1) and return the result
            return BinarySearch2(sortedArray[..middle], target);
        }
        else
        {
            // Search the second half (index middle to end) and return the result
            return BinarySearch2(sortedArray[middle..], target);
        }
    }
}

    // Recursion to sum elements in an array
    // the performance is O(n) because each element in the array
    // needs to be visited once to compute the sum.
    public static int SumArray(int[] arr, int n)
    {
        if (n <= 0)
            return 0; // Base case
        return arr[n - 1] + SumArray(arr, n - 1);
    }

    // recursion to sum from 1 to n
    // the performance is O(n) because there are n recursive calls made before reaching the base case.
    public static int SumToN(int n)
    {
        if (n <= 0)
            return 0; // Base case
            if (n == 1)
            return 1;
        return n + SumToN(n - 1);
    }




}