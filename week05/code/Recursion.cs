using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // TODO Start Problem 1
        // Base case
        // when n is less than or equal to 0, return 0
        if (n <= 0)
            return 0;
        return (n * n) + SumSquaresRecursive(n - 1);
        
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        // this method performance is O(n!) because the number of permutations of a string of length n is n!

        // base case
        // when the word length matches the desired size, add to results
        // if the size is 1, just add each letter to results
        // check thr size is between 1 and length of letters
        // if the current word length matches the desired size, add to results
        if (word.Length == size)
        {
            results.Add(word);
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
                PermutationsChoose(results, lettersLeft, size, word + letters[i]);
            }
        }

        // the performance is O(n!) because the number of permutations of a string of length n is n!
        // also, the function makes recursive calls reducing the problem size each time until reaching the base case.
        // thus, the overall time complexity is dominated by the number of permutations generated.
        // space complexity is O(n) due to the recursion stack and temporary strings created during the process.
        // alternately we can enhance the performance by using backtracking to avoid creating new strings at each step.
        // the backtracking approach would modify the letters in place and revert changes after recursive calls.
        // however, this would require a different data structure (like a char array) to allow in-place modifications.
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        /*if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // TODO Start Problem 3

        // Solve using recursion
        decimal ways = CountWaysToClimb(s - 1) + CountWaysToClimb(s - 2) + CountWaysToClimb(s - 3);
        return ways;*/
        // base cases
        if (s == 0)
            return 1; // There's one way to stay at the ground (do nothing)
        if (s < 0)
            return 0; // No way to climb negative stairs

        // Initialize the memoization dictionary on the first call
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }
        // If we've already computed the value for 's', return it from the dictionary
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }
        // Compute the value recursively and store it in the dictionary
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways;
        return ways;
        // The performance of this memoized version is O(s) because each value from 0 to s is computed only once and stored for future reference.
        // The space complexity is also O(s) due to the storage of computed values in the dictionary.
        // Without memoization, the performance would be exponential O(3^s) due to the overlapping subproblems in the recursive calls.
        // Thus, memoization significantly improves efficiency for larger values of 's'.
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4
        // base case
        //if the string is empty, add to results
        if (pattern == "")
        {
            results.Add(pattern);
            return;
        }
        // if there are no wildcards left in the pattern, add it to results
        // find the index of the first wildcard
        int wildcardIndex = pattern.IndexOf('*');
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
        }
        else
        {
            // replace the wildcard with '0' and recurse
            string patternWithZero = pattern.Substring(0, wildcardIndex) + '0' + pattern.Substring(wildcardIndex + 1);
            WildcardBinary(patternWithZero, results);

            // replace the wildcard with '1' and recurse
            string patternWithOne = pattern.Substring(0, wildcardIndex) + '1' + pattern.Substring(wildcardIndex + 1);
            WildcardBinary(patternWithOne, results);
        }
        // The performance of this function is O(2^m), where m is the number of wildcards in the pattern.
        // This is because each wildcard can be replaced by either '0' or '1', leading to an exponential number of combinations.
        // The space complexity is also O(2^m) due to the storage of all possible binary strings in the results list.
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // Add current position to the path
        currPath.Add((x, y));

        // TODO Start Problem 5
        // ADD CODE HERE
        // Check if we have reached the end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            // Backtrack: remove the current position before returning
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }
        // Explore possible moves: right, down, left, up
        var directions = new List<ValueTuple<int, int>>()
        {
            (1, 0), // right
            (0, 1), // down
            (-1, 0), // left
            (0, -1) // up
        };
        foreach (var (dx, dy) in directions)
        {
            int newX = x + dx;
            int newY = y + dy;
            // Check if the move is valid
            if (maze.IsValidMove(currPath, newX, newY))
            {
                // Recurse with the new position
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }
        // Backtrack: remove the current position before returning
        currPath.RemoveAt(currPath.Count - 1);

        // The performance of this function is O(4^(n^2)) in the worst case, where n is the dimension of the maze.
        // This is because from each cell, there are up to 4 possible directions to explore, and in the worst case, we may need to explore all cells in the maze.
        // However, the actual performance may be better due to the constraints imposed by walls and already visited cells.
        // The space complexity is O(n^2) due to the recursion stack and the storage of the current path.
      


        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
    }
}