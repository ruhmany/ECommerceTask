using ECommerceTask.Application.DTOs;
using ECommerceTask.Domain.Interfaces.Repositories;
using ECommerceTask.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTask.Domain.Entities;
using AutoMapper;
using ECommerceTask.Application.Command.UserCommands;

namespace ECommerceTask.Application.CommandsHandlers.UserCommandsHandlers
{
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserCommandHandler(IServiceProvider provider)
        {
            _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
            _authService = provider.GetRequiredService<IAuthService>();
            _userRepository = provider.GetRequiredService<IUserRepository>();
            _mapper = provider.GetRequiredService<IMapper>();
        }

        public async Task<AuthModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var checkuserbyusername = await _userRepository.GetUserByUsername(request.Username);
            var checkuserbyemail = await _userRepository.GetByEmail(request.Email);

            if (checkuserbyemail is not null || checkuserbyusername is not null)
            {
                return null;
            }
            _authService.CreateHashPassword(request.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            var User = _mapper.Map<User>(request);
            User.PasswordHash = PasswordHash;
            User.PasswordSalt = PasswordSalt;
            User.LastLoginTime = DateTime.UtcNow;
            User.Token = "";
            var refreshtoken = _authService.CreateRefreshToken();
            User.RefreshTokens = new List<RefreshToken>
            {
                refreshtoken
            };
            await _userRepository.AddUser(User);
            await _unitOfWork.CommitChangesAsync();
            User.Token = _authService.CreateToken(User);
            _userRepository.Update(User);
            await _unitOfWork.CommitChangesAsync();
            var authModel = _mapper.Map<AuthModel>(User);

            authModel.RefreshToken = refreshtoken.Token;
            authModel.RefreshTokenExpiration = refreshtoken.ExpiredOn;
            return authModel;
        }
    }
}
