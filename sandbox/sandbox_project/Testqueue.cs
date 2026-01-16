using System;
using System.Collections.Generic;
using System.Diagnostics;
// Test 1
// Scenario: Ensure that after adding 3 items to the queue, they
// can be removed in the proper order
// Expected Result: 100, 200, 300


public class QueueTests {    
    public static void Run() {
// Test 1
    Console.WriteLine("Test 1");


var queue = new Queue<int>();
queue.Enqueue(100);
queue.Enqueue(200);
queue.Enqueue(300);

var result = queue.Dequeue();
Trace.Assert(result == 100);
Console.WriteLine(result);



result = queue.Dequeue();
Trace.Assert(result == 200);
Console.WriteLine(result);

result = queue.Dequeue();
Trace.Assert(result == 200, "Expected 300 here");
Console.WriteLine(result);
// Defect(s) Found: None
}
}
