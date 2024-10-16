using Store.Data.Entity;
using Store.Repository.InterFace;
using Store.Service.Services.Products;
using Store.Service.Services.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services
{
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork) { 
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var Brands= await _unitOfWork.Reposiatory<ProductBrand, int>().GetAllAsync();
            IReadOnlyList<BrandTypeDetailsDto> MappedBrands = Brands.Select(x => new BrandTypeDetailsDto
            {
                Id = x.ID,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
            }).ToList();
            return MappedBrands;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllProductsAsysn()
        {
            var products = await _unitOfWork.Reposiatory<Product, int>().GetAllAsync();
            IReadOnlyList<ProductDto> MappedProducts = products.Select(x => new ProductDto
            {
                Id = x.ID,
                Name = x.Name,
                BrandName=x.Brand.Name,
                TypeName=x.Type.Name,
                Description=x.Description,
                CreatedAt = x.CreatedAt,
                ImageUrl=x.ImageUrl,
                Price=x.Price,
            }).ToList();
            return MappedProducts;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var Types = await _unitOfWork.Reposiatory<ProductType, int>().GetAllAsync();
            IReadOnlyList<BrandTypeDetailsDto> MappedTypes = Types.Select(x => new BrandTypeDetailsDto
            {
                Id = x.ID,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
            }).ToList();
            return MappedTypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int? id)
        {
            if(id is null)
            {
                throw new Exception("ID is NULL");
            }
            var product= await _unitOfWork.Reposiatory<Product, int>().GetByIDAsync(id.Value);
            if(product is null)
            {
                throw new Exception("Product Not Found");
            }
            var MappedProducts = new ProductDto
            {
                Id = product.ID,
                Name = product.Name,
                BrandName = product.Brand.Name,
                TypeName = product.Type.Name,
                Description = product.Description,
                CreatedAt = product.CreatedAt,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            };
            return MappedProducts;
        }
    }
}
