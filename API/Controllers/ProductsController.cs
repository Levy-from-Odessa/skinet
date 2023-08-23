using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Core.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly IProductRepository _productRepository;
    public ProductsController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
      var products = await _productRepository.GetProductsAsync();
      return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      var product = await _productRepository.GetProductByIdAsync(id);
      return Ok(product);
    }


  }
}