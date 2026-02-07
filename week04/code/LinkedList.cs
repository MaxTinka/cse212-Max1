using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    public void InsertHead(int value) { /* implementation */ }
    public void InsertTail(int value) { /* implementation */ }
    public void RemoveHead() { /* implementation */ }
    public void RemoveTail() { /* implementation */ }
    public void InsertAfter(int value, int newValue) { /* implementation */ }
    public void Remove(int value) { /* implementation */ }
    public void Replace(int oldValue, int newValue) { /* implementation */ }
    
    IEnumerator IEnumerable.GetEnumerator() { /* implementation */ }
    public IEnumerator<int> GetEnumerator() { /* implementation */ }
    public IEnumerable Reverse() { /* implementation */ }
    
    public override string ToString() { /* implementation */ }
    public Boolean HeadAndTailAreNull() { /* implementation */ }
    public Boolean HeadAndTailAreNotNull() { /* implementation */ }
}

// EXTENSION METHOD MUST BE INCLUDED
public static class IntArrayExtensionMethods 
{
    public static string AsString(this IEnumerable array) 
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
