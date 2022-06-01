namespace ArityhmeticOperations
{
    public class ArityhmeticOperation
    {
        private static int secondNumber;

        public static int MathOperations(int firstNumber, char Operator, int secondNumber)
        {
            switch (Operator)
            {
                case '+':
                    return Sum(firstNumber, secondNumber);
                case '-':
                    return Subtraction(firstNumber, secondNumber);
                case '*':
                    return Multiplication(firstNumber, secondNumber);
                case '/':
                    return Division(firstNumber, secondNumber);
                case '%':
                    return Modulus(firstNumber, secondNumber);
                default:
                    throw new Exception("Enter arithmetic operator only");
            }
        }
        public static int Sum(int firstNumber, int secondNumber)
        {
            return (firstNumber + secondNumber);
        }
        public static int Subtraction(int firstNumber, int secondNumber)
        {
            return (firstNumber - secondNumber);
        }
        public static int Multiplication(int firstNumber, int secondNumberb)
        {
            return (firstNumber * secondNumber);
        }
        public static int Division(int firstNumber, int secondNumber)
        {
            return (firstNumber / secondNumber);
        }
        public static int Modulus(int firstNumber, int secondNumber)
        {
            return (firstNumber % secondNumber);
        }


    }
}