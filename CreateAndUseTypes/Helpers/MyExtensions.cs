// REMEMBER EXTENSION METHOD MUST BE IN THE SAME SCOPE WITH THE TYPE EXTENDED.
namespace CreateAndUseTypes.Entities
{
    // Extends the Product by adding a discount extension method.
    public static class MyExtensions
    {
        public static decimal Discount(this Product product)
        {
            return product.Price * 9M;
        }
    }
}
