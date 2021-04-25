namespace Demo_07_NullableLibrary
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? Middlename { get; set; }
        public string NationalNumber { get; set; }

        public Person(string firstname, string lastname, string nationalNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            NationalNumber = nationalNumber;
        }
    }
}
