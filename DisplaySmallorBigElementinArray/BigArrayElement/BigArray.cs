namespace BigArrayElement
{
    public class BigArray
    {
        public static int BigElement(int Number, int[] Array2)
        {
            Array.Sort(Array2);
            int result = 0;
            Array.Reverse(Array2);

            for (int i = 0; i < Array2.Length; i++)
            {
                if (i == Number - 1)
                    result = Array2[i];
            }

            return result;
        }
    }
}