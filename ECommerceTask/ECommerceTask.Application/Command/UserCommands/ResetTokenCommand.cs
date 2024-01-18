using ECommerceTask.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Application.Command.UserCommands
{
    public class ResetTokenCommand : IRequest<AuthModel>
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
