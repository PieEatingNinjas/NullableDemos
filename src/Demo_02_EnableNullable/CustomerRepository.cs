namespace Demo_02_EnableNullable
{
    public static class CustomerRepository
    {
        public static Customer? GetCustomer(int id)
        {
            if (id == 0)
                return null;

            return new Customer(id, "John", "Doe");
        }
    }
}
