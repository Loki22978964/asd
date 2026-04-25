using ConsoleApp1.Collections;
using ConsoleApp1.Extensions;
using ConsoleApp1.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var sampleData = new[] {
            new Student("Petrenko", "Ivan", EducationForm.budgetary),
            new Student("Avramenko", "Oleg", EducationForm.contractual),
            new Student("Sydorenko", "Anna", EducationForm.budgetary),
            new Student("Boiko", "Maria", EducationForm.contractual),
            new Student("Hryhorenko", "Denys", EducationForm.budgetary)
        };

// 1
Console.WriteLine("    Level 1: Selection Sort (Array)    ");
var array1 = (Student[])sampleData.Clone();
Console.WriteLine("Before:");
PrintArray(array1);

array1.SelectionSort();

Console.WriteLine("\nAfter:");
PrintArray(array1);
Console.WriteLine(new string('-', 50));

// 2 
Console.WriteLine("\n     Level 2: Selection Sort (Doubly Linked List)     ");
var list = new DoublyLinkedList<Student>();
foreach (var s in sampleData)
{
    list.Add(s);
}

Console.WriteLine("Before:");
list.PrintAll();

list.SelectionSort();

Console.WriteLine("\nAfter:");
list.PrintAll();
Console.WriteLine(new string('-', 50));

// 3
Console.WriteLine("\n     Level 3: Quick Sort (Array)    ");
var array3 = (Student[])sampleData.Clone();
Console.WriteLine("Before:");
PrintArray(array3);

array3.QuickSort(0, array3.Length - 1);

Console.WriteLine("\nAfter:");
PrintArray(array3);


static void PrintArray(Student[] arr) => Console.WriteLine(string.Join("\n", (object[])arr));