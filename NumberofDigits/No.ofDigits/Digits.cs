namespace No.ofDigits
{
    public class Digits
    {
        public static int Count(int Number)
        {
            int Result = 0;
            while (Number != 0)
            {
                Number = Number / 10;
                Result++;
            }
            return Result;

        }
    }
}