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
        // Step 1: Understand the requirement
        //   - We need to create an array of size 'length'
        //   - First element is the number itself
        //   - Each subsequent element is a multiple of the number
        //   - Example: MultiplesOf(7, 5) → {7, 14, 21, 28, 35}
        //   - Pattern: array[i] = number × (i + 1)
        //
        // Step 2: Create the array with correct size
        //   - Use 'new double[length]' to create array
        //   - This gives us an array with 'length' elements
        //
        // Step 3: Fill the array using a loop
        //   - Loop from i = 0 to i < length
        //   - For each position i:
        //     - Calculate: number × (i + 1)
        //     - Store in array[i]
        //   - Why (i + 1)? Because:
        //     - When i=0: number × (0+1) = number (first multiple)
        //     - When i=1: number × (1+1) = number × 2 (second multiple)
        //     - etc.
        //
        // Step 4: Return the completed array
        // ====================================================
        
        // Step 2: Create array with specified size
        double[] result = new double[length];
        
        // Step 3: Fill the array with multiples
        for (int i = 0; i < length; i++)
        {
            // Calculate (i+1)th multiple of the number
            result[i] = number * (i + 1);
        }
        
        // Step 4: Return the array
        return result; // replace this return statement with your own
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
        // Step 1: Understand the rotation requirement
        //   - We're rotating the list RIGHT by 'amount' positions
        //   - Last 'amount' elements move to the front
        //   - Example: {1,2,3,4,5,6,7,8,9}, amount=3 → {7,8,9,1,2,3,4,5,6}
        //   - Amount is always valid: 1 ≤ amount ≤ data.Count
        //
        // Step 2: Check edge cases
        //   - If data is null or has 0-1 elements, nothing to do
        //   - If amount equals data.Count, full rotation returns to original
        //
        // Step 3: Calculate split point
        //   - We need to find where to split the list
        //   - Elements from split point to end should move to front
        //   - splitIndex = data.Count - amount
        //   - Example: 9 elements, amount=3 → splitIndex = 9-3 = 6
        //     Elements at indices 6,7,8 (values 7,8,9) move to front
        //
        // Step 4: Extract the elements to move
        //   - Use GetRange(splitIndex, amount) to get last 'amount' elements
        //   - Store them in a temporary list
        //
        // Step 5: Remove those elements from original list
        //   - Use RemoveRange(splitIndex, amount) to remove them
        //
        // Step 6: Insert the elements at the beginning
        //   - Use InsertRange(0, tempList) to add them to front
        //
        // Alternative approach: Could create new list and replace data,
        // but modifying in-place is more memory efficient.
        // ====================================================
        
        // Step 2: Handle edge cases
        if (data == null || data.Count <= 1)
        {
            // Nothing to rotate if list is null or has 0-1 elements
            return;
        }
        
        // If amount equals data.Count, rotation brings us back to start
        if (amount == data.Count)
        {
            return;
        }
        
        // Step 3: Calculate split point
        int splitIndex = data.Count - amount;
        
        // Step 4: Get the elements that need to move to front
        List<int> elementsToMove = data.GetRange(splitIndex, amount);
        
        // Step 5: Remove those elements from their current position
        data.RemoveRange(splitIndex, amount);
        
        // Step 6: Insert the elements at the beginning
        data.InsertRange(0, elementsToMove);
        
        // Alternative implementation (commented out):
        // List<int> rotated = new List<int>();
        // rotated.AddRange(data.GetRange(data.Count - amount, amount)); // Last 'amount' elements
        // rotated.AddRange(data.GetRange(0, data.Count - amount));      // First part
        // data.Clear();
        // data.AddRange(rotated);
    }
}
