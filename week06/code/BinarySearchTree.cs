using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    public void Insert(int value)
    {
        if (_root is null)
        {
            _root = new Node(value);
        }
        else
        {
            _root.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    public IEnumerable<int> Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    // Problem 3: Traverse Backwards
    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            // Traverse right subtree first (larger values)
            TraverseBackward(node.Right, values);
            
            // Add current node
            values.Add(node.Data);
            
            // Traverse left subtree (smaller values)
            TraverseBackward(node.Left, values);
        }
    }

    public int GetHeight()
    {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}
