using System.Collections.Generic;

using System.Linq;

namespace Triangle.Extensions
{
    public static class CollectionExtention
    {
        public static IEnumerable<T[]> GetCombinations<T>(this IEnumerable<T> collection)
        {
            int arrayCount = collection.Count();
            int end_1 = arrayCount - 2;
            int end_2 = arrayCount - 1;
            int end_3 = arrayCount;
            for (int index_1 = 0; index_1 < end_1; index_1++)
            {
                for (int index_2 = index_1 + 1; index_2 < end_2; index_2++)
                {
                    for (int index_3 = index_2 + 1; index_3 < end_3; index_3++)
                    {
                        yield return new T[] {
                            collection.ElementAt(index_1),
                            collection.ElementAt(index_2),
                            collection.ElementAt(index_3)};
                    }

                }
            }
        }
    }
}
