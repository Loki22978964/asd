using ConsoleApp1.BinaryTree;
using ConsoleApp1.models;

Console.OutputEncoding = System.Text.Encoding.UTF8;
BinaryTree tree = new BinaryTree();

// LEVEL 1: Creation and Output
// Names: Miller, Andrew (3rd year, July) - Matches
tree.Add(new Student("Miller", "Andrew", 3, "AC-100", new DateTime(2005, 7, 15)));
// Names: Smith, Julia (2nd year, June) - No match (wrong course)
tree.Add(new Student("Smith", "Julia", 2, "AC-050", new DateTime(2006, 6, 10)));
// Names: Brown, Igor (3rd year, January) - No match (wrong month)
tree.Add(new Student("Brown", "Igor", 3, "AC-120", new DateTime(2005, 1, 20)));
// Names: Wilson, Helen (3rd year, August) - Matches
tree.Add(new Student("Wilson", "Helen", 3, "AC-080", new DateTime(2005, 8, 05)));
// Names: Taylor, Oleg (4th year, December) - No match
tree.Add(new Student("Taylor", "Oleg", 4, "AC-200", new DateTime(2004, 12, 12)));

Console.WriteLine("--- LEVEL 1: Initial Tree State (In-order) ---");
tree.PrintTable();

Console.WriteLine("--- LEVEL 2: Searching for specific students ---");
tree.FindSpecificStudents();

Console.WriteLine("--- LEVEL 3: Deleting students found by criteria ---");
tree.DeleteSpecificStudents();

Console.WriteLine("Tree state after deletion:");
tree.PrintTable();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();