using ECommerceTask.API.Controllers;
using ECommerceTask.API.DTOs;
using ECommerceTask.Application.Command.ProductCommands;
using ECommerceTask.Application.Queries.ProductQueries;
using ECommerceTask.Domain.Entities;
using ECommerceTask.Infrastructre;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECOmmerceTask.Test.Controllers
{
    public class ProductControllerTests
    {

        private IWebHostEnvironment _hostingEnvironment;
        private IConfiguration _configuration;

        public ProductControllerTests()
        {
            _hostingEnvironment = A.Fake<IWebHostEnvironment>();
            A.CallTo(() => _hostingEnvironment.WebRootPath).Returns("wwwroot");

            _configuration = A.Fake<IConfiguration>();
            A.CallTo(() => _configuration["FileStoragePath"]).Returns("uploads");
        }


        [Fact]
        public async Task GetList_ReturnsOk()
        {
            // Arrange
            var dbContext = CreateFakeDbContext();  // Create a fake instance of your DbContext
            var mediator = A.Fake<IMediator>();
            var controller = new ProductController(A.Fake<IWebHostEnvironment>(), A.Fake<IConfiguration>(), mediator);

            // Act
            var result = await controller.GetList(new GetListOfProductsQuery());

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        // Helper method to create a fake instance of ApplicationDbContext
        private ApplicationDbContext CreateFakeDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase") // You can use an in-memory database or any other appropriate options
                .Options;

            return A.Fake<ApplicationDbContext>(x => x.WithArgumentsForConstructor(() => new ApplicationDbContext(dbContextOptions)));
        }

        [Fact]
        public async Task GetProduct_ValidQuery_ReturnsOk()
        {
            // Arrange           
            var mediator = A.Fake<IMediator>();
            A.CallTo(() => mediator.Send(A<GetProductByIdQuery>._, A<CancellationToken>._)).Returns(new Product()); // Assuming a valid result
            var controller = new ProductController(A.Fake<IWebHostEnvironment>(), A.Fake<IConfiguration>(), mediator);

            // Act
            var result = await controller.GetProduct(new GetProductByIdQuery());

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetProduct_InvalidQuery_ReturnsNotFound()
        {
            // Arrange
            var mediator = A.Fake<IMediator>();
            A.CallTo(() => mediator.Send(A<GetProductByIdQuery>._, A<CancellationToken>._)).Returns((Product)null); // Assuming an invalid result
            var controller = new ProductController(A.Fake<IWebHostEnvironment>(), A.Fake<IConfiguration>(), mediator);

            // Act
            var result = await controller.GetProduct(new GetProductByIdQuery());

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task AddProduct_ValidDTO_ReturnsOk()
        {
            // Arrange
            var mediator = A.Fake<IMediator>();
            A.CallTo(() => mediator.Send(A<AddProductCommand>._, A<CancellationToken>._)).Returns(new Product()); // Assuming a valid result
            var controller = new ProductController(A.Fake<IWebHostEnvironment>(), A.Fake<IConfiguration>(), mediator);

            // Act
            var result = await controller.AddProduct(new AddProductDTO());

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task UpdateProduct_ValidDTO_ReturnsOk()
        {
            // Arrange
            var mediator = A.Fake<IMediator>();
            A.CallTo(() => mediator.Send(A<UpdateProductCommand>._, A<CancellationToken>._)).Returns(new Product()); // Assuming a valid result
            var controller = new ProductController(A.Fake<IWebHostEnvironment>(), A.Fake<IConfiguration>(), mediator);

            // Act
            var result = await controller.UpdateProduct(new UpdateProductDTO());

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task DeleteProduct_ValidId_ReturnsOk()
        {
            // Arrange
            var mediator = A.Fake<IMediator>();
            A.CallTo(() => mediator.Send(A<DeleteProductCommand>._, A<CancellationToken>._)).Returns(new Product()); // Assuming a valid result
            var controller = new ProductController(A.Fake<IWebHostEnvironment>(), A.Fake<IConfiguration>(), mediator);

            // Act
            var result = await controller.DeleteProduct("TestId");

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

    }

}
