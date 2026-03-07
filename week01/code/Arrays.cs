using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step-by-step plan:
        // 1. Create a new array of doubles with size 'length'.
        // 2. Loop through the indices from 0 to length-1.
        // 3. For each index i, calculate the multiple as number * (i + 1).
        // 4. Store the multiple in the array at index i.
        // 5. Return the filled array.

        double[] result = new double[length]; // step 1

        for (int i = 0; i < length; i++) // step 2
        {
            result[i] = number * (i + 1); // step 3 & 4
        }

        return result; // step 5
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    /// This function modifies the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step-by-step plan:
        // 1. Get the size of the list.
        // 2. If amount is equal to the size, no rotation is needed.
        // 3. Split the list into two parts:
        //    a) Last 'amount' elements that will move to the front.
        //    b) First 'n - amount' elements that will follow after.
        // 4. Clear the original list.
        // 5. Add the last 'amount' elements first.
        // 6. Add the first 'n - amount' elements after.
        // 7. The original list is now rotated.

        int n = data.Count; // step 1

        if (amount == n) return; // step 2

        List<int> endSlice = data.GetRange(n - amount, amount); // step 3a
        List<int> startSlice = data.GetRange(0, n - amount);   // step 3b

        data.Clear();        // step 4
        data.AddRange(endSlice);   // step 5
        data.AddRange(startSlice); // step 6
    }
}