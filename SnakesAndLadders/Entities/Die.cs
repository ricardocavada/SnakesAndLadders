namespace SnakesAndLadders.Entities
{
    public class Die
    {
        const int MINIMUM_DIE_VALUE = 1;
        const int MAXIMUM_DIE_VALUE = 6;

        public static int GetMinumumValue()
        {
            return MINIMUM_DIE_VALUE;
        }

        public static int GetMaximumValue()
        {
            return MAXIMUM_DIE_VALUE;
        }
    }
}
