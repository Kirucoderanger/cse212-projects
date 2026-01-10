public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Steps:
        // 1. Create an array of doubles with the specified length.
        // 2. Loop from 0 to length - 1.
        // 3. In each iteration, calculate the multiple of the number by (i + 1) and assign it to the array at index i.
        // 4. After the loop, return the array.
        // Implementation:
            double[] results = new double[length]; // Create an array to hold the results
            for (int i = 0; i < length; i++) // Loop through each index of the array
            {
                results[i] = number * (i + 1); // Calculate the multiple and assign it to the array
            }
            return results; // Return the populated array

        //return []; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Steps:
        // 1. Determine the number of elements in the list.
        // 2. Calculate the effective rotation amount using modulo operation.
        // 3. Extract the last 'amount' elements from the list.
        // 4. Remove these elements from their original position.
        // 5. Insert the extracted elements at the beginning of the list.
        // 6. The list is now rotated to the right by the specified amount.
        // Implementation:
        int count = data.Count; // Get the count of elements in the list
        amount = amount % count; // In case amount is greater than count
        List<int> tempStuck = data.GetRange(count - amount, amount); // Store the last 'amount' elements in a temporary list
        data.RemoveRange(count - amount, amount); // Remove the last 'amount' elements from the original list
        data.InsertRange(0, tempStuck); // Insert the stored elements at the beginning of the list

    }
}

//run.MultiplesOf(7, 5); // should return {7, 14, 21, 28, 35}
//var list = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9};
//run.RotateListRight(list, 3); // list should now be {7, 8, 9, 1, 2, 3, 4, 5, 6}
//run.RotateListRight(list, 1); // list should now be {6, 7, 8, 9, 1, 2, 3, 4, 5}
//run.RotateListRight(list, 9); // list should now be {6, 7, 8, 9, 1, 2, 3, 4, 5}
//run.RotateListRight(list, 10); // list should now be {5, 6, 7, 8, 9, 1, 2, 3, 4}
