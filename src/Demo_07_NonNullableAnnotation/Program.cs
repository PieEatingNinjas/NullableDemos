using Demo_07_NullableLibrary;

namespace Demo_07_NonNullableAnnotation
{
    class Program
    {
        static void Main(string[] args)
        {
            DoStuffInNonNullableAnnotationsContext();
            DoStuffInNullableAnnotaionsContext();
        }

        //Nullable annotations context enabled in this method.
        //With the unary postfix (!) we can always force null values.
        static void DoStuffInNullableAnnotaionsContext()
        {
#nullable enable
            var repo = new PersonRepository();

            Person p = repo.GetById(5)!;

            repo.IsUnique(null!);
            repo.Save(null!);
#nullable restore
        }

        //This library doesn't have nullable annotations context enabled.
        //No warnings or anything when passing nulls to methods that don't allow nullable types, no notion about nullable return types
        static void DoStuffInNonNullableAnnotationsContext()
        {
            var repo = new PersonRepository();

            Person p = repo.GetById(5);

            repo.IsUnique(null);
            repo.Save(null);
        }
    }
}
