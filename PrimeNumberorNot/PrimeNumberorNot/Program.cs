// See https://aka.ms/new-console-template for more information
using PrimeNumber;
Console.WriteLine("Enter Number");
int Number = Convert.ToInt32(Console.ReadLine());
Boolean result = PrimeNum.Prime(Number);
if (!result)
{
   Console.WriteLine("Given Number is Prime");
}
else
{ 
    Console.WriteLine("Given Number is Not Prime");
}
