using ECommerceTask.API.DTOs;
using ECommerceTask.Application.Command.ProductCommands;
using ECommerceTask.Application.Queries.ProductQueries;
using ECommerceTask.Infrastructre;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public ProductController(IWebHostEnvironment hostingEnvironment, IConfiguration configuration, IMediator mediator)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpGet("get-list")]
        public async Task<IActionResult> GetList([FromQuery]GetListOfProductsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);  
        }

        [HttpGet("get-product")]
        public async Task<IActionResult> GetProduct([FromQuery]GetProductByIdQuery query)
        {
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromForm]AddProductDTO dto)
        {
            var command = new AddProductCommand
            {
                Name = dto.Name,
                Category = dto.Category,
                ImagePath = await SaveImage(dto.Image),
                Price = dto.Price,
                MinQuantity = dto.MinQuantity,
                DiscountRate = dto.DiscountRate,
            };
            var result = await _mediator.Send(command);
            
            return Ok(result);
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct([FromForm]UpdateProductDTO dto)
        {
            var command = new UpdateProductCommand
            {
                Id = dto.Id,
                Name = dto.Name,
                Category = dto.Category,
                ImagePath = await SaveImage(dto.Image),
                Price = dto.Price,
                MinQuantity = dto.MinQuantity,
                DiscountRate = dto.DiscountRate,
            };
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProduct(string Id)
        {
            var command = new DeleteProductCommand { ID = Id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        private async Task<string> SaveImage(IFormFile image)
        {
            try
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{image.FileName}";
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["FileStoragePath"], uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                // Return the relative path of the saved image
                return Path.Combine(_configuration["FileStoragePath"], uniqueFileName);
            }
            catch (Exception ex)
            {                
                throw;
            }
        }
    }
}
