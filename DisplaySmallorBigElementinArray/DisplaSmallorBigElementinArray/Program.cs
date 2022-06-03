using System;
using ReadArrayElements;
using SmallArrayElement;
using BigArrayElement;
Console.WriteLine("Enter Array Length");
int ArrayLength = Convert.ToInt32(Console.ReadLine());
int[] Array1 = ReadArray.Read(ArrayLength);
Console.WriteLine("Enter do u want SmallNumber or BigNumber small or big ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string Opera = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
switch (Opera)
{
    case "small":
        Console.WriteLine("Enter Which small element");
        int smallNumber=Convert.ToInt32(Console.ReadLine());
         if(Array1.Length >= smallNumber)
        {
            Console.WriteLine("Small Element is : " + SmallArray.SmallElement(smallNumber, Array1));
        }
         else
        {
            Console.WriteLine("Please Enter only Array Length equal or below");
        }
        break;

    case "big":
        Console.WriteLine("Enter Which Big element");
        int bigNumber = Convert.ToInt32(Console.ReadLine());
        if (Array1.Length >= bigNumber)
        {
            Console.WriteLine("Big  Element is : " + BigArray.BigElement(bigNumber, Array1));
        }
        else
        {
            Console.WriteLine("Please Enter only Array Length equal or below");
        }
        break;
    default:
        Console.WriteLine("Please enter only Small/Big NUmbrer");
        break;
}