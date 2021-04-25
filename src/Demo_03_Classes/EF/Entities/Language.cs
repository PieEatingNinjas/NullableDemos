namespace Demo_03_Classes.EF.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public Language(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
