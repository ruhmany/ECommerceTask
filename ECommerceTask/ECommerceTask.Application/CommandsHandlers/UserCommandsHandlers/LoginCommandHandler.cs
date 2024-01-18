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
using ECommerceTask.Application.Command.UserCommands;

namespace ECommerceTask.Application.CommandsHandlers.UserCommandsHandlers
{
    internal class LoginCommandHandler : IRequestHandler<LoginCommand, AuthModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public LoginCommandHandler(IServiceProvider provider)
        {
            _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
            _authService = provider.GetRequiredService<IAuthService>();
            _userRepository = provider.GetRequiredService<IUserRepository>();
        }

        public async Task<AuthModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsername(request.UsernameOrEmail);
            if (user == null)
            {
                return null;
            }
            var isPasswordCorrect = _authService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);
            if (isPasswordCorrect)
            {
                var authModel = new AuthModel();
                authModel.Username = user.UserName;
                authModel.UserType = user.UserType;
                authModel.Token = _authService.CreateToken(user);
                if (user.RefreshTokens.Any(rt => rt.IsActive))
                {
                    var activeRefreshToken = user.RefreshTokens.FirstOrDefault(rt => rt.IsActive);
                    activeRefreshToken.RevokeOn = DateTime.UtcNow;
                }
                var refreshToken = _authService.CreateRefreshToken();
                user.RefreshTokens.Add(refreshToken);
                user.LastLoginTime = DateTime.UtcNow;
                authModel.RefreshToken = refreshToken.Token;
                authModel.RefreshTokenExpiration = refreshToken.ExpiredOn;
                _userRepository.Update(user);
                await _unitOfWork.CommitChangesAsync();
                return authModel;
            }
            return null;
        }
    }
}
