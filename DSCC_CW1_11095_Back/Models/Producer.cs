namespace DSCC_CW1_11095_Back.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
