namespace ProductsService.Controllers.Inputs
{
    public class UnitInput
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }        
    }
}
