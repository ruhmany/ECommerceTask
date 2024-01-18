using AutoMapper;
using ECommerceTask.Application.DTOs;
using ECommerceTask.Domain.Interfaces.Repositories;
using ECommerceTask.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ECommerceTask.Application.Command.UserCommands;

namespace ECommerceTask.Application.CommandsHandlers.UserCommandsHandlers
{
    public class ResetTokenCommandHandler : IRequestHandler<ResetTokenCommand, AuthModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public ResetTokenCommandHandler(IServiceProvider provider)
        {
            _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
            _authService = provider.GetRequiredService<IAuthService>();
            _userRepository = provider.GetRequiredService<IUserRepository>();
            _mapper = provider.GetRequiredService<IMapper>();
        }

        public async Task<AuthModel> Handle(ResetTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsername(request.Username);
            if (user == null)
            {
                return null;
            }
            var rt = user.RefreshTokens.FirstOrDefault(rt => rt.Token == request.RefreshToken);
            if (rt == null || !rt.IsValid)
            {
                return null;
            }
            rt.RevokeOn = DateTime.UtcNow;
            var token = _authService.CreateToken(user);
            var refreshtoken = _authService.CreateRefreshToken();
            user.Token = token;
            user.LastLoginTime = DateTime.UtcNow;
            user.RefreshTokens.Add(refreshtoken);
            _userRepository.Update(user);
            await _unitOfWork.CommitChangesAsync();
            var auth = _mapper.Map<AuthModel>(user);
            auth.RefreshToken = refreshtoken.Token;
            auth.RefreshTokenExpiration = refreshtoken.ExpiredOn;
            return auth;
        }
    }
}
