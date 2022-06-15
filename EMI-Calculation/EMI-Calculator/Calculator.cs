namespace EMI_Calculator
{
    public class Calculator
    {
        public static void Calculation(long Amount)
        {
            long Percentage = (Amount / 100) * 10;
            Console.WriteLine($"1  month You Pay Amount is  : {(Amount + (Percentage * 1))/1}");
            Console.WriteLine($"2  month You Pay Amount is  : {(Amount + (Percentage * 2)) / 2}");
            Console.WriteLine($"3  month You Pay Amount is  : {(Amount + (Percentage * 3)) / 3}");
            Console.WriteLine($"4  month You Pay Amount is  : {(Amount + (Percentage * 4)) / 4}");
            Console.WriteLine($"5  month You Pay Amount is  : {(Amount + (Percentage * 5)) / 5}");
            Console.WriteLine($"6  month You Pay Amount is  : {(Amount + (Percentage * 6)) / 6}");
            Console.WriteLine($"7  month You Pay Amount is  : {(Amount + (Percentage * 7)) / 7}");
            Console.WriteLine($"8  month You Pay Amount is  : {(Amount + (Percentage * 8)) / 8}");
            Console.WriteLine($"9  month You Pay Amount is  : {(Amount + (Percentage * 9)) / 9}");
            Console.WriteLine($"10 month You Pay Amount is  : {(Amount + (Percentage * 10)) / 10}");
            Console.WriteLine($"11 month You Pay Amount is  : {(Amount + (Percentage * 11)) / 11}");
            Console.WriteLine($"12 month You Pay Amount is  : {(Amount + (Percentage * 12)) / 12}");
        }
        public static long Emi(long Amount, int Months)
        {
            long EmiPercentage = (Amount / 100) * 10;
            long TotalAmount = Amount + (EmiPercentage * Months);
            long MonthPay = TotalAmount / Months;
            return MonthPay;
        }
    }
}