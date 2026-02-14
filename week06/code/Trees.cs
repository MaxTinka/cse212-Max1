using System.Collections.Generic;
using System.Linq;

public static class Trees
{
    // Problem 5: Create Tree from Sorted List
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: no elements in current range
        if (first > last)
        {
            return;
        }
        
        // Calculate middle index
        int mid = (first + last) / 2;
        
        // Insert middle element
        bst.Insert(sortedNumbers[mid]);
        
        // Recursively process left half
        InsertMiddle(sortedNumbers, first, mid - 1, bst);
        
        // Recursively process right half
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}

// Extension method for IEnumerable<int> to support the tests
public static class EnumerableExtensions
{
    public static string AsString(this IEnumerable<int> source)
    {
        return "{" + string.Join(", ", source) + "}";
    }
}
