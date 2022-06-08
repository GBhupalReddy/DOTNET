namespace SortArray
{
    internal static class SortArrayElementsHelpers
    {
        public static int[] Arraysort(int[] sortArray)
        {
            int temp = 0;
            for (int i = 0; i < sortArray.Length; i++)
            {
                for (int j = i + 1; j < sortArray.Length; j++)
                {
                    if (sortArray[i] > sortArray[j])
                    {
                        temp = sortArray[i];
                        sortArray[i] = sortArray[j];
                        sortArray[j] = temp;
                    }
                }
            }
        }
    }
}