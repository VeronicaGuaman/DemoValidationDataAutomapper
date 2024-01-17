namespace DemoValidationDataAutomapper.Application.Models.Person
{
    public class PersonResponseModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
