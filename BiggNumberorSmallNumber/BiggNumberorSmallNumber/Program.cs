// See https://aka.ms/new-console-template for more inform
using SmallNumber;
using BigNumber;
Console.WriteLine("Enter firstNumber");
int firstNumber=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter secondNumber");
int secondNumber=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter thirdNumber");
int thirdNumber=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter do u want SmallNumber or BigNumber (small/big)");
string Operation=Console.ReadLine();
switch (Operation)
{
    case "small":
        Console.WriteLine("Small Number is" + SmallNum.Small(firstNumber, secondNumber, thirdNumber)) ;
        break;

    case "big":
        Console.WriteLine("Big Number is :  " + BigNum.big(firstNumber, secondNumber, thirdNumber));
        break;
   default:
        Console.WriteLine("It Diplay only Small/Big NUmbrer");
        break;
}

