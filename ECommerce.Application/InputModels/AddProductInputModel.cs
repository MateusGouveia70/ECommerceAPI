namespace ECommerce.Application.InputModels
{
    public class AddProductInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Brand { get; set; }
        public int Category_Id { get; set; }
    }
}
