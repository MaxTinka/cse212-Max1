using System.Collections;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Recursive Squares Sum
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
        {
            return 0;
        }
        
        // Recursive case: n² + sum of squares from 1 to (n-1)
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Permutations Choose
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if word length equals desired size, add to results
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }
        
        // Recursive case: try adding each available letter
        for (int i = 0; i < letters.Length; i++)
        {
            // For permutations, we cannot reuse the same letter in the same word
            if (word.Contains(letters[i]))
            {
                continue;
            }
            
            // Create new word with current letter
            string newWord = word + letters[i];
            
            // Continue building permutations
            PermutationsChoose(results, letters, size, newWord);
        }
    }

    /// <summary>
    /// Problem 3: Climbing Stairs
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize memoization dictionary
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }
        
        // Check if already computed
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }
        
        // Base Cases
        decimal result;
        if (s < 0)
        {
            result = 0;
        }
        else if (s == 0)
        {
            result = 1; // One way to take no steps
        }
        else if (s == 1)
        {
            result = 1; // Only one 1-step
        }
        else if (s == 2)
        {
            result = 2; // 1+1 or 2
        }
        else if (s == 3)
        {
            result = 4; // 1+1+1, 1+2, 2+1, 3
        }
        else
        {
            // Recursive case with memoization
            result = CountWaysToClimb(s - 1, remember) + 
                     CountWaysToClimb(s - 2, remember) + 
                     CountWaysToClimb(s - 3, remember);
        }
        
        // Store result
        remember[s] = result;
        return result;
    }

    /// <summary>
    /// Problem 4: Wildcard Binary Patterns
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Find the first wildcard
        int wildcardIndex = pattern.IndexOf('*');
        
        // Base case: if no wildcards, add pattern to results
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }
        
        // Recursive case: replace wildcard with 0 and 1
        // Use range indexing as suggested in the problem description
        string patternWithZero = pattern[..wildcardIndex] + '0' + pattern[(wildcardIndex + 1)..];
        WildcardBinary(patternWithZero, results);
        
        string patternWithOne = pattern[..wildcardIndex] + '1' + pattern[(wildcardIndex + 1)..];
        WildcardBinary(patternWithOne, results);
    }

    /// <summary>
    /// Problem 5: Maze
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize path if first call
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // Add current position to path
        currPath.Add((x, y));
        
        // Check if reached the end
        if (maze.IsEnd(x, y))
        {
            // Use AsString() as specified in instructions
            results.Add(currPath.AsString());
            // Backtrack
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }
        
        // Try all four directions: down, right, up, left
        (int, int)[] directions = { (0, 1), (1, 0), (0, -1), (-1, 0) };
        
        foreach (var (dx, dy) in directions)
        {
            int newX = x + dx;
            int newY = y + dy;
            
            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }
        
        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}
