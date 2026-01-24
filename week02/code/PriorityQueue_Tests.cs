using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities and dequeue them.
    // Expected Result: Items should be dequeued in order of highest to lowest priority.
    // Defect(s) Found: 
    // - The Dequeue method did not search for the highest priority item
    // - Items were returned in FIFO order regardless of priority
    // - The loop condition was incorrect (stopped one element early)
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority.
    // Expected Result: Items with the same priority should be dequeued in FIFO order.
    // Defect(s) Found:
    // - When multiple items had the same priority, the queue did not preserve FIFO order
    // - The comparison operator was '>=' instead of '>', breaking FIFO tie-breaking
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities, including ties.
    // Expected Result: Highest priority items are dequeued first, and ties are resolved using FIFO.
    // Defect(s) Found:
    // - The algorithm failed to correctly combine priority ordering with FIFO ordering
    // - Items were not being removed from the queue after dequeuing
    public void TestPriorityQueue_MixedPrioritiesWithFIFO()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found:
    // - Initially no exception was thrown when dequeuing from an empty queue
    // - The exception message did not match the required text
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType().Name} caught: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Test Length property during enqueue and dequeue operations.
    // Expected Result: Length should accurately reflect number of items in the queue.
    // Defect(s) Found:
    // - Length property was not implemented or not updating correctly
    // - Items were not being removed from the internal list when dequeued
    public void TestPriorityQueue_LengthProperty()
    {
        var priorityQueue = new PriorityQueue();
        
        Assert.AreEqual(0, priorityQueue.Length);
        
        priorityQueue.Enqueue("A", 1);
        Assert.AreEqual(1, priorityQueue.Length);
        
        priorityQueue.Enqueue("B", 2);
        Assert.AreEqual(2, priorityQueue.Length);
        
        priorityQueue.Dequeue();
        Assert.AreEqual(1, priorityQueue.Length);
        
        priorityQueue.Dequeue();
        Assert.AreEqual(0, priorityQueue.Length);
    }

    [TestMethod]
    // Scenario: Complex scenario with multiple operations.
    // Expected Result: Queue maintains correct priority order after mixed operations.
    // Defect(s) Found:
    // - The queue state became inconsistent after multiple enqueue/dequeue operations
    public void TestPriorityQueue_ComplexOperations()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Task1", 2);
        priorityQueue.Enqueue("Task2", 5);
        Assert.AreEqual("Task2", priorityQueue.Dequeue());
        
        priorityQueue.Enqueue("Task3", 4);
        priorityQueue.Enqueue("Task4", 5);
        
        Assert.AreEqual("Task4", priorityQueue.Dequeue());
        Assert.AreEqual("Task3", priorityQueue.Dequeue());
        Assert.AreEqual("Task1", priorityQueue.Dequeue());
    }
}
