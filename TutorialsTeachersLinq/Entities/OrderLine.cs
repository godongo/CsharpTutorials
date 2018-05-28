namespace TutorialsTeachersLinq.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
