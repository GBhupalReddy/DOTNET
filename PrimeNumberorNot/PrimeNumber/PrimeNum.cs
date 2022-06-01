namespace PrimeNumber
{
    public class PrimeNum
    {
        public static Boolean Prime(int a)
        {
            Boolean result = false;
            for (int i = 2; i < a / 2; i++)
            {
                if (a % i == 0)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

    }
}