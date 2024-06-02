namespace ProductsService.Controllers.CustomModels
{
    public class UnitModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }        
        
    }
}
