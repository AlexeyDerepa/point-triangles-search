using System;
using System.Collections.Generic;

using System.Linq;
using System.Numerics;

namespace Triangle.Extensions
{
    public static class CollectionExtention
    {
        public static IEnumerable<T[]> GetCombinations<T>(this IEnumerable<T> collection, int subSet)
        {
            int collectionSize = collection.Count();
            BigInteger countOfCombination = BigInteger.Pow(2, collectionSize);
            for (BigInteger index = 0; index < countOfCombination; index++)
            {
                var indexes = GetIndexex(index);
                if (indexes.Count() == subSet)
                {
                    T[] result = indexes
                        .Select(currentIndex => collection.ElementAt(currentIndex))
                        .ToArray();

                    yield return result;
                }
            }
        }

        private static IEnumerable<int> GetIndexex(BigInteger number)
        {
            for (int index = 0; number > 0; index++)
            {
                if (number % 2 == 1)
                {
                    yield return index;
                }

                number = number / 2;
            }
        }
        public static IEnumerable<T[]> GetData<T>(
            this (BigInteger start, BigInteger end) range,
            ICollection<T> collection, int subSet = 3)
        {
            for (BigInteger index = range.start; index < range.end; index++)
            {
                IEnumerable<int> data = GetIndexex(index);
                if (data.Count() == subSet)
                {
                    yield return data.Select(x => collection.ElementAt(x)).ToArray();
                }
            }
        }
        public static IEnumerable<(BigInteger start, BigInteger end)> GetRenges<T>(
            this ICollection<T> collection,
            int exponent = 20)
        {
            BigInteger arrLength = BigInteger.Pow(2, collection.Count());
            BigInteger offSet = (int)Math.Pow(2, exponent);

            for (BigInteger index = 0; index < arrLength; index += offSet)
            {
                BigInteger end = index + offSet - 1;
                yield return (index, end >= arrLength ? arrLength : end);
            }
        }
    }
}
