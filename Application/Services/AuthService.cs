using Application.DTOs.Auth;
using Application.Interfaces;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using BCrypt.Net;
using Microsoft.Extensions.Logging;
using Application.Constants;


namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthService> _logger;
        private readonly IJWTTokenGenerator _jwtTokenGenerator;

        public AuthService(IUserRepository userRepository, ILogger<AuthService> logger,
            IJWTTokenGenerator jWTTokenGenerator)
        {
            _userRepository = userRepository;
            _logger = logger;
            _jwtTokenGenerator = jWTTokenGenerator;
        }


        public async Task<Result<RegisterResponseDto>> RegisterAsync(RegisterDto dto,
            CancellationToken cancellationToken = default)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email, cancellationToken);
            if (existingUser != null)
            {
                _logger.LogWarning("Registration failed - user with this email {Email} already exists.", dto.Email);
                return Result<RegisterResponseDto>.Failure(ErrorMessages.UserAlreadyExists);
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User(dto.Email, passwordHash, dto.FirstName, dto.LastName);

            await _userRepository.AddAsync(user, cancellationToken);
            await _userRepository.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("New user is registered - {Email} (ID: {UserId})", user.Email, user.Id);

            var response = new RegisterResponseDto(user.Id, user.Email, user.FirstName, user.LastName);
            return Result<RegisterResponseDto>.Success(response);
        }

        public async Task<Result<LoginResponseDto>> LoginAsync(LoginDto dto,
            CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email, cancellationToken);
            if (user == null)
            {
                _logger.LogWarning("Login with email {Email} failed - user does not exist.", dto.Email);
                return Result<LoginResponseDto>.Failure(ErrorMessages.InvalidEmailOrPassword);
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                _logger.LogWarning("Login with email {Email} failed - wrong password.", dto.Email);
                return Result<LoginResponseDto>.Failure(ErrorMessages.InvalidEmailOrPassword);
            }

            var token = _jwtTokenGenerator.GenerateToken(user);
            _logger.LogInformation("Successful login for email {Email} (ID: {UserId})", user.Email, user.Id);

            return Result<LoginResponseDto>.Success(new LoginResponseDto(token, user.Id, user.Email));
        }
    }
}