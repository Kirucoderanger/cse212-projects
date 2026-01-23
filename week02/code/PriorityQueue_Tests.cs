using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: shall add an item (which contains both data and priority) to the back of the queue
    // Expected Result: book (Pri:5), pen (Pri:2), laptop (Pri:8) 
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        //Assert.Fail("Implement the test case and then remove this.");
        priorityQueue.Enqueue("book", 5);
        priorityQueue.Enqueue("pen", 2);
        priorityQueue.Enqueue("laptop", 8);
        Assert.AreEqual("[book (Pri:5), pen (Pri:2), laptop (Pri:8)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: shall remove the item with the highest priority and return its value
    // Expected Result: book (Pri:5), pen (Pri:2), laptop (Pri:8) 
    // Defect(s) Found: The last item was not being considered when determining the highest priority.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        //Assert.Fail("Implement the test case and then remove this.");
        priorityQueue.Enqueue("book", 5);
        priorityQueue.Enqueue("pen", 2);
        priorityQueue.Enqueue("laptop", 8);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("laptop", result);
       // continue dequeuing to verify the order
        result = priorityQueue.Dequeue();
        Assert.AreEqual("book", result);
        result = priorityQueue.Dequeue();
        Assert.AreEqual("pen", result);

    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: If there are more than one item with the highest priority, 
    // then the item closest to the front of the queue will be removed and its value returned
    // Expected Result: laptop
    // Defect(s) Found: None
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("book", 5);
        priorityQueue.Enqueue("laptop", 8);
        priorityQueue.Enqueue("pen", 8);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("laptop", result);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty priority queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: None
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}