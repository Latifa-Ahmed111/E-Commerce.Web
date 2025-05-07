using AutoMapper;
using DomainLayer.Contracts;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServicesMange(IUnitOfWork unitofwork,IMapper mapper) : ISevicesManger
    {
        private readonly Lazy<IProductService> LazyProductServices = new  Lazy< IProductService>(()=> new ProductServices(unitofwork,mapper));
        public IProductService ProductService => LazyProductServices.Value;
    }
}
