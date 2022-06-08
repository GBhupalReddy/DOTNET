// See https://aka.ms/new-console-template for more information
using ReadArray;
using SortArray;
Console.WriteLine("Enter Array Length");
int ArrayLength = Convert.ToInt32(Console.ReadLine());
int[] Array = ReadArrayElements.Read(ArrayLength);
Console.WriteLine("Before Sorting Array Elements");
for (int i = 0; i < ArrayLength; i++)
{
    Console.WriteLine(Array[i]);
}
Console.WriteLine("After Sorting Array Elements");
int [] sortArray = SortArrayElements.Arraysort(Array);
for (int i = 0; i < sortArray.Length; i++)
{
    Console.WriteLine(sortArray[i]);
}
