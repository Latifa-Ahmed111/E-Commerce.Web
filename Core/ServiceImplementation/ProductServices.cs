using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.Products;
using Service.Spesfications;
using ServiceAbstraction;
using Shared;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class ProductServices(IUnitOfWork unitOfWork,IMapper mapper) : IProductService
    {

        public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParam productQuery)
        {
            var _Reposatory = unitOfWork.GetReposatory<Product, int>();
            var spec = new ProductWithBrandandTypeSpesfication(productQuery);
            var Products = await _Reposatory.GetAllAsync(spec);
            var MapperProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);

            var productcount = Products.Count();

            var CountSpesfication = new ProuductCountSpesfication(productQuery);
            var TotalCount = await _Reposatory.CountAsync(CountSpesfication);
            return new PaginatedResult<ProductDto>(productQuery.PageIndex, productcount, TotalCount, MapperProducts);
        }





        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var _Reposatory = unitOfWork.GetReposatory<ProductBrand, int>();
            var Brands=await _Reposatory.GetAllAsync();
            var MapperBrands = mapper.Map<IEnumerable< ProductBrand>,IEnumerable< BrandDto>>(Brands);

            return MapperBrands;
        }

        

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var _Reposatory = unitOfWork.GetReposatory<ProductType, int>();
            var Types = await _Reposatory.GetAllAsync();
            var MapperTypes = mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);

            return MapperTypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var Spec = new ProductWithBrandandTypeSpesfication(id);

            var Product =  await unitOfWork.GetReposatory<Product, int>().GetByIdAsync(Spec);
            if(Product is null)
            {
                throw new ProductNotFoundException(id);
            }

            return mapper.Map<Product,ProductDto>(Product);
        }
    }
}
