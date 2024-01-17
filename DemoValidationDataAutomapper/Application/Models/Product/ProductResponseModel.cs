namespace DemoValidationDataAutomapper.Application.Models.Product
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
