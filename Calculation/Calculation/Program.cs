// See https://aka.ms/new-console-template for more information
using ArityhmeticOperations;
Console.WriteLine("Enter firstNumber");
int firstNumber = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter arithmetic operator");
char Operator = Convert.ToChar(Console.ReadLine());
Console.WriteLine("Enter secondNumber");
int secondNumber = Convert.ToInt32(Console.ReadLine());
try
{
    Console.WriteLine("Result: " + ArityhmeticOperation.MathOperations(firstNumber, Operator, secondNumber));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message.ToString());
}