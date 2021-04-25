using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Demo_05_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var itemsNonNull = new string[]
            {
                 "Item1",
                 "Item2",
                 "Item3"
            };

            var itemsNull = new string?[]
            {
                "Item1",
                null,
                "Item3"
            };

            var itemsInt = new int?[]
            {
                1, 2, 3
            };

            var result = CollectionHelper.Find2(itemsNonNull, (e) => e == "Item4");

            Console.WriteLine(result?.ToUpper() ?? "NULL");

            var intResult = CollectionHelper.Find(itemsInt, (e) => e == 4);

            var result2 = CollectionHelper.Find(itemsNull, (e) => e == "Item4");

            Console.WriteLine(result2?.ToUpper() ?? "null");
        }
    }

    public static class CollectionHelper
    {
        //[return: MaybeNull]
        //public static T Find<T>(T[] array, Func<T, bool> match)
        //{
        //    return array.FirstOrDefault(match);
        //}

        //Only supported in .NET 5.
        //Prior to .NET 5 you will need to add class or struct constraint if you want to return nullable (or use MaybeNull attribute)
        public static T? Find<T>(T?[] array, Func<T?, bool> match)
        {
            return array.FirstOrDefault(match);
        }

        //Additional notnull constraint to disallow nullable type argument
        public static T? Find2<T>(T[] array, Func<T, bool> match) where T : notnull
        {
            return array.FirstOrDefault(match);
        }
    }
}
