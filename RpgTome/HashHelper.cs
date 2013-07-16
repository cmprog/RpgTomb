namespace RpgTome
{
    public static class HashHelper
    {
        public const int Start = 23;
        private const int sMultiplier = 31;

        public static int GetHashCode<T>(T value)
        {
            return (value == null) ? Start : value.GetHashCode();
        }

        public static int GetHashCode<T1, T2>(T1 value1, T2 value2)
        {
            return Start
                .CombineHash(value1)
                .CombineHash(value2);
        }

        public static int GetHashCode<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
        {
            return Start
                .CombineHash(value1)
                .CombineHash(value2)
                .CombineHash(value3);
        }

        public static int GetHashCode<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            return Start
                .CombineHash(value1)
                .CombineHash(value2)
                .CombineHash(value3)
                .CombineHash(value4);
        }

        public static int CombineHash<T>(this int aggregateHash, T value)
        {
            var lValueHash = (value == null) ? Start : value.GetHashCode();
            return aggregateHash*sMultiplier + lValueHash;
        }
    }
}
