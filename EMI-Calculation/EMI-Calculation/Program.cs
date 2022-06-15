// See https://aka.ms/new-console-template for more information
using EMI_Calculator;
Console.WriteLine("Enter How Much Amount You Want");
long Amount=Convert.ToInt64(Console.ReadLine());
Calculator.Calculation(Amount);
Console.WriteLine("Enter How many Months of EMI");
int Months=Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"You Pay Every Month Amount is : {Calculator.Emi(Amount,Months)}  ");

