public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        // The insert function should add the value to the tree in the correct position
        // The insert function should not allow duplicate values in the tree.  If a duplicate value is inserted, the tree should remain unchanged.
        // The insert function should maintain the binary search tree property, which means that for any given node, all values in the left subtree should be less than the node's value, and all values in the right subtree should be greater than the node's value.
        // The insert function should have a time complexity of O(log n) on average, where n is the number of nodes in the tree.  In the worst case (when the tree is completely unbalanced), the time complexity can degrade to O(n).
        // Check for duplicates before inserting
        if (value == Data)
        {
            Console.WriteLine($"Value {value} already exists in the tree. No duplicates allowed.");
            return;
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

    public bool Contains(int value)
    {
        // TODO Start Problem 2
            // The contains function should return true if the value is found in the tree, and false otherwise.
            // The contains function should have a time complexity of O(log n) on average, 
            // where n is the number of nodes in the tree.  In the worst case (when the tree is completely unbalanced), 
            // the time complexity can degrade to O(n).
        if (value == Data)
        {
            return true; // Value found at the current node base case
        }
        else if (value < Data)
        {
            // Search to the left
            return Left != null && Left.Contains(value);
        }
        else
        {
            // Search to the right
            return Right != null && Right.Contains(value);
        }
        
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // The GetHeight function should return the height of the tree, 
        // which is defined as the number of edges on the longest path from the node to a leaf.  
        // A leaf is a node that has no children.
        // The GetHeight function should have a time complexity of O(n), 
        // where n is the number of nodes in the tree, because it needs to visit each node in the tree to calculate the height.
        
        // Base case: if the node is null, return 0
        if (this == null)
        {
            return 0;
        }
        // Recursive case: return 1 plus the maximum height of the left and right subtrees
        int leftHeight = Left != null ? Left.GetHeight() : 0;
        int rightHeight = Right != null ? Right.GetHeight() : 0;
        return 1 + Math.Max(leftHeight, rightHeight);

    }
}