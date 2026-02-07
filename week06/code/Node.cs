public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // Problem 1: Insert Unique Values Only
    public void Insert(int value)
    {
        // Check for duplicate - if value equals Data, don't insert
        if (value == Data)
        {
            return; // Value already exists
        }
        
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // Problem 2: Contains
    public bool Contains(int value)
    {
        if (value == Data)
        {
            return true;
        }
        
        if (value < Data)
        {
            // Search left subtree
            return Left?.Contains(value) ?? false;
        }
        else
        {
            // Search right subtree
            return Right?.Contains(value) ?? false;
        }
    }

    // Problem 4: Tree Height
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        
        // Height = 1 (current node) + max of left/right subtree heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
