using System;

namespace Demo_07_NullableLibrary
{
    public class PersonRepository
    {
        public Person? GetById(int i)
        {
            if (i == 1)
                return new Person("Pieter", "Nijs", "123-45678-901");
            else
                return null;
        }

        public void Save(Person p)
        {
            if(IsUnique(p.NationalNumber))
            {
                //Store in DB
            }
            else
            {
                throw new Exception();
            }
        }

        public bool IsUnique(string nationalNumber)
        {
            var normalized = nationalNumber.Replace("-", "");
            //Search in DB

            return true;
        }
    }
}
