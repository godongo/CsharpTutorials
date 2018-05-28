using CreateAndUseTypes.Entities;


namespace CreateAndUseTypes.Entities
{
    // Uses the extension method to calculate the discount.
    public class Calculator
    {
        public decimal CalculateDiscount(Product p)
        {          
            return p.Discount();
        }
    }
}
