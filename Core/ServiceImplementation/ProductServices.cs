using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models.Products;
using Service.Spesfications;
using ServiceAbstraction;
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
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var _Reposatory = unitOfWork.GetReposatory<ProductBrand, int>();
            var Brands=await _Reposatory.GetAllAsync();
            var MapperBrands = mapper.Map<IEnumerable< ProductBrand>,IEnumerable< BrandDto>>(Brands);

            return MapperBrands;
        }

        public  async Task<IEnumerable<ProductDto>> GetAllProductsAsync(int? BrandId ,int? TypeId)
        {
            var _Reposatory = unitOfWork.GetReposatory<Product, int>();
            var spec = new ProductWithBrandandTypeSpesfication(BrandId, TypeId);
            var Products = await _Reposatory.GetAllAsync(spec);
            var MapperProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);

            return MapperProducts;
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

            return mapper.Map<Product,ProductDto>(Product);
        }
    }
}
