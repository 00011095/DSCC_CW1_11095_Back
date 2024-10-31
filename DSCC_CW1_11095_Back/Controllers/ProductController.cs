using AutoMapper;
using DSCC_CW1_11095_Back.Dtos;
using DSCC_CW1_11095_Back.Interfaces;
using DSCC_CW1_11095_Back.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSCC_CW1_11095_Back.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);
            await _productRepository.AddAsync(product);

            var productDto = _mapper.Map<ProductDto>(product);
            return CreatedAtRoute("GetProductById", new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductCreateDto productUpdateDto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return NotFound();

            _mapper.Map(productUpdateDto, product);
            await _productRepository.UpdateAsync(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return NotFound();

            await _productRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
