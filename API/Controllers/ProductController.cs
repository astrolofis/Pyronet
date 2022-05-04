using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pyronet.Repo.Data;
using pyronet.Core.Entities;
using pyronet.Core.interfaces;
using Core.interfaces;
using Core.Specification;
using API.Dtos;
using AutoMapper;
using API.Controllers;

namespace pyronet.API.Controllers
{
      
    public class ProductController: BaseApiController
    {        
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepo, 
        IGenericRepository<ProductBrand> productBrandRepo, 
        IGenericRepository<ProductType> productTypeRepo,
        IMapper mapper)
        {
            _mapper=mapper;
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;                      
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToDto>>> GetProducts()
        {
            var spec=new ProductMapSpecification();
            var products=await _productRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToDto>>(products));      
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToDto>> GetProduct(int id)
        {
            var spec=new ProductMapSpecification(id);
            var product= await _productRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product,ProductToDto>(product);
       }
       [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductBrands()
        {            
            return Ok(await _productBrandRepo.ListAllAsync());      
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductTypes()
        {            
            return Ok(await _productTypeRepo.ListAllAsync());      
        }
    }
}   