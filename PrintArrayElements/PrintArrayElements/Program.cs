// See https://aka.ms/new-console-template for more information
using ReadArrayElements;
Console.WriteLine("Enter Array Length");
int ArrayLength=Convert.ToInt32(Console.ReadLine());
int [] Array = ReadArray.Read(ArrayLength);
for(int i = 0; i < ArrayLength; i++)
{
    Console.WriteLine(Array[i]);
}