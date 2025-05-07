using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(ISevicesManger ServiceManger ):ControllerBase
    {
        //GetallProduct 
        [HttpGet]
        //GetUrl/api/Products
        public async Task<ActionResult<PaginatedResult< ProductDto>>>GetAllProducts([FromQuery]ProductQueryParam productQuery )
        {

            var Products = await ServiceManger.ProductService.GetAllProductsAsync(productQuery);

            return Ok(Products);
        }

        [HttpGet("brands")]
        //GetUrl/api/Products
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllBrands()
        {

            var Brands = await ServiceManger.ProductService.GetAllBrandsAsync();

            return Ok(Brands);
        }

        [HttpGet("types")]
        //GetUrl/api/Products
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {

            var Types = await ServiceManger.ProductService.GetAllTypesAsync();

            return Ok(Types);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>>GetProductById(int id )
        {

            var Product = await ServiceManger.ProductService.GetProductByIdAsync(id);
            return Product;

        }

    }
}
