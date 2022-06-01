namespace BigNumber
{
    public class BigNum
    {
        public static int big(int firstNumber, int secondNumber, int thirdNumber)
        {
            if ((firstNumber > secondNumber) && (firstNumber > thirdNumber))
            {
                return firstNumber;
            }
            else if ((secondNumber > firstNumber) && (secondNumber > thirdNumber))
            {
                return secondNumber;
            }
            else
            {
                return thirdNumber;
            }
        }
    }
}