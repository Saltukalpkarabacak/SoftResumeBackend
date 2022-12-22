using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services;
using Application.Services.AuthService;
using Core.Security.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    /// <summary>
    /// Kullanıcı giriş işlemini gerçekleştiren komut sınıfı
    /// </summary>
    public class LoginCommand : IRequest<LoginedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        /// <summary>
        /// Kullanıcı giriş işlemini gerçekleştiren işleyici sınıfı
        /// </summary>
        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginedDto>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;

            public LoginCommandHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService)
            {
                _authBusinessRules = authBusinessRules;
                _userRepository = userRepository;
                _authService = authService;
            }

            public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.UserShouldBeExistWhenLogin(request.UserForLoginDto.Email);
                var user = await _userRepository.GetAsync(x => x.Email == request.UserForLoginDto.Email);
                _authBusinessRules.CheckIfPasswordIsCorrect(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);

                var createdAccessToken = await _authService.CreateAccessToken(user);
                var createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                return new LoginedDto()
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = addedRefreshToken
                };
            }
        }
    }
}
