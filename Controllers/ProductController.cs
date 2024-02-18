using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwiftCarpenter.Domain.Entities;
using swiftcarpenterApi.Domain.Dtos;
using swiftcarpenterApi.Services.Features.Products;
using System;
using System.Net.WebSockets;

namespace swiftcarpenterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(ProductService productService, IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            var productsDto = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return Ok(productsDto);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            if (product.Id <= 0)
            {
                return NotFound();
            }
            var dto = _mapper.Map<ProductDTO>(product);
            return Ok(dto);
        }


        [HttpGet("getProduct")]
        public async Task<IActionResult> GetId(int productTypeId, int sizeId, int materialId, int finishTypeId, int colorId)
        {
            var product = await _productService.GetId(productTypeId, sizeId,  materialId, finishTypeId,  colorId);

            if (product.Id <= 0)
            {
                return NotFound();
            }
            var productDTO = _mapper.Map<ProductDTO>(product);
            return Ok(productDTO);
        }
        //CATALOGOS
        [HttpGet("ProductType")]
        public async Task<IActionResult> GetTypeProductAll()
        {
            var productsType = await _productService.GetAllProductType();
            var productsTypeDTO = _mapper.Map<IEnumerable<ProductTypeDTO>>(productsType);
            return Ok(productsTypeDTO);
        }


        [HttpGet("Material")]
        public async Task<IActionResult> GetMaterialAll()
        {
            var Material = await _productService.GetMaterialAll();
            var materialDTO = _mapper.Map<IEnumerable<MaterialDTO>>(Material);

            return Ok(materialDTO);
        }

        [HttpGet("Size")]
        public async Task<IActionResult> GetSizeAll()
        {
            var sizes = await _productService.GetSizeAll();
            var sizesDTO = _mapper.Map<IEnumerable<SizeResponseDTO>>(sizes);


            return Ok(sizesDTO);
        }

        [HttpGet("Color")]
        public async Task<IActionResult> GetColorAll()
        {
            var color = await _productService.GetColorAll();
             var colorDTO = _mapper.Map<IEnumerable<ColorResponseDTO>>(color);
            return Ok(colorDTO);
        }

        [HttpGet("FinishType")]
        public async Task<IActionResult> GetFinishTypeAll()
        {
            var finishType = await _productService.GetFinishTypes();
            var finishTypeDTO = _mapper.Map<IEnumerable<FinishTypeDTO>>(finishType);

            return Ok(finishTypeDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productService.Update(product);
            return NoContent();
        }

       
    }
}
