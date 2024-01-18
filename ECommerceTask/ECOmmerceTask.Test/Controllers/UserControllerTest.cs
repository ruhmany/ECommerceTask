using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using Castle.Core.Configuration;
using ECommerceTask.API.Controllers;
using ECommerceTask.Application.Command.UserCommands;
using ECommerceTask.Application.DTOs;
using FakeItEasy;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECOmmerceTask.Test.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        public async Task Register_ValidCommand_ReturnsOk()
        {
            // Arrange
            var mediator = A.Fake<IMediator>();
            var configuration = A.Fake< Microsoft.Extensions.Configuration.IConfiguration >();
            var serviceProvider = new ServiceCollection()
                .AddSingleton(mediator)
                .AddSingleton(configuration)
                .AddSingleton<IValidator<RegisterUserCommand>>(A.Fake<IValidator<RegisterUserCommand>>())
                .AddSingleton<IValidator<LoginCommand>>(A.Fake<IValidator<LoginCommand>>())
                .BuildServiceProvider();

            var controller = new UserController(serviceProvider);

            // Act
            var result = await controller.Register(new RegisterUserCommand());

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task Login_ValidQuery_ReturnsOk()
        {
            // Arrange
            var mediator = A.Fake<IMediator>();
            var configuration = A.Fake<Microsoft.Extensions.Configuration.IConfiguration>();
            var serviceProvider = new ServiceCollection()
                .AddSingleton(mediator)
                .AddSingleton(configuration)
                .AddSingleton<IValidator<RegisterUserCommand>>(A.Fake<IValidator<RegisterUserCommand>>())
                .AddSingleton<IValidator<LoginCommand>>(A.Fake<IValidator<LoginCommand>>())
                .BuildServiceProvider();

            var controller = new UserController(serviceProvider);

            // Act
            var result = await controller.Login(new LoginCommand());

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task Refresh_ValidModel_ReturnsOk()
        {
            // Arrange
            var mediator = A.Fake<IMediator>();
            var configuration = A.Fake<Microsoft.Extensions.Configuration.IConfiguration>();
            var serviceProvider = new ServiceCollection()
                .AddSingleton(mediator)
                .AddSingleton(configuration)
                .AddSingleton<IValidator<RegisterUserCommand>>(A.Fake<IValidator<RegisterUserCommand>>())
                .AddSingleton<IValidator<LoginCommand>>(A.Fake<IValidator<LoginCommand>>())
                .BuildServiceProvider();

            var controller = new UserController(serviceProvider);

            // Act
            var result = await controller.Refresh(new ResetTokenCommand());

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }


        private string GenerateValidToken()
        {
            // Use Bogus to generate a valid token for testing
            var faker = new Faker();
            return faker.Random.AlphaNumeric(32);
        }
    }
}
