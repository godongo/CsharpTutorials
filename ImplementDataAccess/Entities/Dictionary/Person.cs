namespace ImplementDataAccess.Entities.Dictionary
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int Age { get; internal set; }
    }
}
