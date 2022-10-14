namespace ETicaretAPI.Domain.Entities
{
    public class ProductImages:File
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Quality { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
