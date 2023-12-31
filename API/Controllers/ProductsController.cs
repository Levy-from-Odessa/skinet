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
    private readonly IGenericRepository<Product> _productRepo;
    private readonly IGenericRepository<ProductBrand> _productBrandRepo;
    private readonly IGenericRepository<ProductType> _productTypeRepo;
    public ProductsController(
      IGenericRepository<Product> productRepo, 
      IGenericRepository<ProductBrand> productBrandRepo, 
      IGenericRepository<ProductType> productTypeRepo
      )
    {
      _productRepo = _productRepo;
      _productBrandRepo = _productBrandRepo;
      _productTypeRepo = _productTypeRepo;
    }
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
      var products = await _productRepo.ListAllAsync();
      return Ok(products);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<ProductBrand>> GetProductBrands()
    {
      var brands = await _productBrandRepo.ListAllAsync();
      return Ok(brands);
    }
    [HttpGet("types")]
    public async Task<ActionResult<ProductType>> GetProductTypes()
    {
      var types = await _productTypeRepo.ListAllAsync();
      return Ok(types);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      var product = await _productRepo.getByIdAsync(id);
      return Ok(product);
    }


  }
}