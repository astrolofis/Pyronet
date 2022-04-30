using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pyronet.Repo.Data;
using pyronet.Core.Entities;
using pyronet.Core.interfaces;

namespace pyronet.API.Controllers
{
      [ApiController]
    [Route("api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProductrepository _repo;
        
        public ProductController(IProductrepository repo)
        {
            _repo = repo;
           
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products=await _repo.GetProductAsync();
            return Ok(products);      
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
       }
       [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductBrands()
        {            
            return Ok(await _repo.GetProductBrandAsync());      
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductTypes()
        {            
            return Ok(await _repo.GetProductTypeAsync());      
        }
    }
}   