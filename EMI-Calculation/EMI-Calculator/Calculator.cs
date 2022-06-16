namespace EMI_Calculator
{
    public class Calculator
    {
        public static void Calculation(long Amount, long Downpayment)
        {
            long RemainingAmount = Amount - Downpayment;
            float Percentage = (RemainingAmount / 100) * 5;
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine($"{i}  month You Pay Amount is  : {(RemainingAmount + (Percentage * i)) / i}");
            }
        }
        public static float Emi(long Amount, int Months)
        {
            float EmiPercentage = (Amount / 100) * 5;
            float TotalAmount = Amount + (EmiPercentage * Months);
            float MonthPay = TotalAmount / Months;
            return MonthPay;
        }
    }
}