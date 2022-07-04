namespace Generic_Demo.Core
{
    public class Comparision
    {
        public bool Compar<t>(t value1, t value2)
        {
            if(value1 == null || value2 == null)
            {
                return false;
            }
            return value1.Equals(value2);
        }


    }
}