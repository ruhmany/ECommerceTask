using AutoMapper;
using ECommerceTask.Application.Command.ProductCommands;
using ECommerceTask.Application.Command.UserCommands;
using ECommerceTask.Application.DTOs;
using ECommerceTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserCommand, User>();
            CreateMap<User, AuthModel>();
            CreateMap<AddProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
