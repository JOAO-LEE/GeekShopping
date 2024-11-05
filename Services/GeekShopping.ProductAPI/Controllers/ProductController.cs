using GeekShopping.ProductAPI.Data.DTO;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GeekShopping.ProductAPI.Controller
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
      _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> FindAll()
    {
      var product = await _repository.FindAll();
      return Ok(product);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> FindById(long id)
    {
      var product = await _repository.FindById(id);
      if (product.Id <= 0) return NotFound();
      return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Create(ProductDTO prod)
    {
      if (prod == null) return BadRequest();
      var product = await _repository.Create(prod);
      return Ok(product);
    }

    [HttpPut]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Update(ProductDTO prod)
    {
      if (prod == null) return BadRequest();
      var product = await _repository.Update(prod);
      return Ok(product);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductDTO>> Delete(long id)
    {
      var status = await _repository.Delete(id);
      if (!status) return BadRequest();
      return NoContent();
    }
  }
}