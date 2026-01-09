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
        
        // ====================================================
        // PLAN FOR MULTIPLESOF FUNCTION:
        // ====================================================
        // Step 1: Understand what needs to be done
        //   - Input: A starting number and how many multiples we need
        //   - Output: An array containing the multiples
        //   - Example: MultiplesOf(3, 5) → {3, 6, 9, 12, 15}
        //   - Pattern: Each element = number × (position + 1)
        //   - Position 0: number × 1 = 3
        //   - Position 1: number × 2 = 6
        //   - Position 2: number × 3 = 9
        //   - etc.
        //
        // Step 2: Create the array with correct size
        //   - We know we need 'length' elements
        //   - Create array: double[] result = new double[length];
        //
        // Step 3: Fill the array using a loop
        //   - Loop from i = 0 to i < length
        //   - For each position i, calculate: number × (i + 1)
        //   - Store in result[i]
        //
        // Step 4: Return the completed array
        // ====================================================
        
        // Step 2: Create array with specified size
        double[] result = new double[length];
        
        // Step 3: Fill the array with multiples
        for (int i = 0; i < length; i++)
        {
            // Calculate the (i+1)th multiple
            // i=0 → number × 1 (first multiple)
            // i=1 → number × 2 (second multiple)
            // i=2 → number × 3 (third multiple)
            result[i] = number * (i + 1);
        }
        
        // Step 4: Return the array
        return result;
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
        
        // ====================================================
        // PLAN FOR ROTATELISTRIGHT FUNCTION:
        // ====================================================
        // Step 1: Understand the rotation operation
        //   - Rotating right means moving elements from the end to the beginning
        //   - Example: {1,2,3,4,5,6,7,8,9}, amount=3
        //     Last 3 elements (7,8,9) move to front
        //     Result: {7,8,9,1,2,3,4,5,6}
        //   - Amount is always between 1 and data.Count
        //
        // Step 2: Check for simple cases
        //   - If list is null or empty, do nothing
        //   - If list has only 1 element, rotation does nothing
        //   - If amount equals data.Count, full rotation returns to original
        //
        // Step 3: Calculate where to split the list
        //   - We need to move the last 'amount' elements to the front
        //   - Split point = data.Count - amount
        //   - Example: 9 elements, amount=3 → split point = 9-3 = 6
        //     Elements from index 6 to end (indices 6,7,8) move to front
        //
        // Step 4: Use list slicing to solve the problem
        //   - Get the last 'amount' elements using GetRange(splitIndex, amount)
        //   - Store them in a temporary list
        //   - Remove them from original list using RemoveRange(splitIndex, amount)
        //   - Insert them at the beginning using InsertRange(0, tempList)
        //
        // Step 5: Alternative approach (not using list methods)
        //   - Could create a new list and build it manually
        //   - Or could rotate elements one by one using modulo arithmetic
        //   - But the list slicing approach is clean and efficient
        // ====================================================
        
        // Step 2: Handle edge cases
        if (data == null || data.Count <= 1)
        {
            // Nothing to rotate if list is null or has 0-1 elements
            return;
        }
        
        // If amount equals the list length, rotation does nothing
        if (amount == data.Count)
        {
            return;
        }
        
        // Step 3: Calculate the split point
        // We want the last 'amount' elements to move to the front
        int splitIndex = data.Count - amount;
        
        // Step 4: Use list slicing to perform the rotation
        // Get the elements that need to move to the front (last 'amount' elements)
        List<int> elementsToMove = data.GetRange(splitIndex, amount);
        
        // Remove those elements from their current position at the end
        data.RemoveRange(splitIndex, amount);
        
        // Insert them at the beginning of the list
        data.InsertRange(0, elementsToMove);
        
        // Alternative implementation using a new list (commented out):
        // List<int> rotated = new List<int>();
        // // Add the last 'amount' elements first
        // rotated.AddRange(data.GetRange(data.Count - amount, amount));
        // // Add the remaining elements
        // rotated.AddRange(data.GetRange(0, data.Count - amount));
        // // Clear the original and add the rotated elements
        // data.Clear();
        // data.AddRange(rotated);
        
        // Alternative implementation using modulo and single loop (commented out):
        // List<int> temp = new List<int>(data);
        // for (int i = 0; i < data.Count; i++)
        // {
        //     // New position for element at index i
        //     int newIndex = (i + amount) % data.Count;
        //     data[newIndex] = temp[i];
        // }
    }
}
