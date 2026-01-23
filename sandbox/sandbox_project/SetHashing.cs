using System.Collections.Generic;

// Example usage of HashSet for set operations
public class SetHashing
{
public static void Run()
{

var set1 = new HashSet<int>(){1,2,3,4,5};
var set2 = new HashSet<int>(){4,5,6,7,8};
var set3 = set1.Intersect(set2).ToHashSet(); // This will result in {4, 5}
var set4 = set1.Union(set2).ToHashSet();     // This will result in {1, 2, 3, 4, 5, 6, 7, 8}
Console.WriteLine("Intersection: " + string.Join(", ", set3));
Console.WriteLine("Union: " + string.Join(", ", set4));
}
}

       