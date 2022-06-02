namespace ReadArrayElements
{
    public class ReadArray
    {
        public static int[] Read(int Number)
        { 
            int [] array = new int[Number];
            for(int i = 0; i < Number; i++)
            {
                Console.WriteLine($"Enter {i} index Number : ");
                array[i]=Convert.ToInt32(Console.ReadLine());
            }
            return array;
        }
    }
}