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



namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public async Task<Result<RegisterResponseDto>> RegisterAsync(RegisterDto dto, CancellationToken cancellationToken = default)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email, cancellationToken);
            if (existingUser != null)
                return Result<RegisterResponseDto>.Failure("User with this email already exists.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User(dto.Email, passwordHash, dto.FirstName, dto.LastName);

            await _userRepository.AddAsync(user, cancellationToken);
            await _userRepository.SaveChangesAsync(cancellationToken);

            var response = new RegisterResponseDto(user.Id, user.Email, user.FirstName, user.LastName);
            return Result<RegisterResponseDto>.Success(response);
        }
    }
}
