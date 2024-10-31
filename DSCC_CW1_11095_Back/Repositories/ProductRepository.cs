using DSCC_CW1_11095_Back.Data;
using DSCC_CW1_11095_Back.Interfaces;
using DSCC_CW1_11095_Back.Models;

namespace DSCC_CW1_11095_Back.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }
    }
}
