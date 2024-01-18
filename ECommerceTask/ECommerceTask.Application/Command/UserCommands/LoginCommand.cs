using ECommerceTask.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Application.Command.UserCommands
{
    public class LoginCommand : IRequest<AuthModel>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
