﻿/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Add customer and serve customer
        // Expected Result: Display the customer that was added
        Console.WriteLine("Test 1");
        var service = new CustomerService(4);
        service.AddNewCustomer();
        service.ServeCustomer();

        // Defect(s) Found: Index was out of range because I was removing the customer before getting it, so I fixed the order of those two operations

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add two customers and serve them in order
        // Expected Result: Display customers in the order they were added, first in, first out 
        Console.WriteLine("Test 2");
        service = new CustomerService(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After serving customers: {service}");


        // Defect(s) Found: None  

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
        // Test 3
        // Scenario: Try to serve a customer when there are no customers
        // Expected Result: Display an error message
        Console.WriteLine("Test 3");
        service = new CustomerService(4);
        service.ServeCustomer();
        // Defect(s) Found: Needed to check the length of the queue before serving a customer to avoid errors

        Console.WriteLine("=================");
        // Test 4
        // Scenario: Try to add more customers than the max queue size
        // Expected Result: Display an error message when trying to add the 3rd customer
        Console.WriteLine("Test 4");
        service = new CustomerService(2);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Service Queue: {service}");
        // Defect(s) Found: Needed to do >= instead of > when checking the length of the queue in AddNewCustomer

        Console.WriteLine("=================");
        //Test 5
        // Scenario: Enforce max queue to 10 when given invalid size
        // Expected Result: Max queue size should be 10
        Console.WriteLine("Test 5");
        service = new CustomerService(-5);
        Console.WriteLine($"Max Queue Size: {service}");
        // Defect(s) Found: none
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        //if (_queue.Count > _maxSize) { // Defect 3 - should use >=
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        // Defect-2 Check if there are customers in the queue, if not display message.
        if (_queue.Count == 0) {
            Console.WriteLine("No Customers in Queue.");
            
        }
        else {
        /*_queue.RemoveAt(0);
        var customer = _queue[0];*/ 
        // Fixed the order of these two operations, so first get the customer then remove it from the queue
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}