namespace SmallArrayElement
{
    internal static class SmallArrayHelpers
    {
        public static int SmallElement(int Number, int[] Array2)
        {
            Array.Sort(Array2);
            int Result=0;
            for (int i = 0; i < Array2.Length; i++)
            {
                if (i == Number - 1)
                {
                    return Result = Array2[i];
                }
            }
            return Result;
        }
    }
}