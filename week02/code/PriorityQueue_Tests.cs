using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities and dequeue them.
    // Expected Result: Items should be dequeued in order of highest to lowest priority.
    // Defect(s) Found:
    // - Dequeue did not always return the item with the highest priority.
    // - The queue sometimes behaved like a normal FIFO queue instead of prioritizing values.
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
    // - When multiple items had the same priority, the queue did not preserve FIFO order.
    // - Later items with equal priority were sometimes returned before earlier ones.
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
    // - The queue failed to correctly combine priority ordering with FIFO ordering.
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
    // - No exception was thrown when dequeuing from an empty queue.
    // - The exception message did not match the required text.
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
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                e.GetType(), e.Message)
            );
        }
    }
}
