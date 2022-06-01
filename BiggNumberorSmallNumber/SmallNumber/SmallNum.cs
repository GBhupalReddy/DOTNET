namespace SmallNumber
{
    public class SmallNum
    { 
        public static int Small(int firstNumber, int secondNumber, int thirdNumber)
        {
            if ((firstNumber < secondNumber) && (firstNumber < thirdNumber))
            {
                 return firstNumber;
            }
            else if ((secondNumber < firstNumber) && (secondNumber < thirdNumber))
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