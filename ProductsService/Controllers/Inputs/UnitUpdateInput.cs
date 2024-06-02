namespace ProductsService.Controllers.Inputs
{
    public class UnitUpdateInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
