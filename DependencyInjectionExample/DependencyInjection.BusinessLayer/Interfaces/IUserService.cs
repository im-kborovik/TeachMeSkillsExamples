using DependencyInjection.BusinessLayer.Dtos;

namespace DependencyInjection.BusinessLayer.Interfaces;

public interface IUserService
{
    Task<IReadOnlyCollection<UserResponseDto>> GetUsers();

    Task<UserResponseDto> GetUser(Guid userId);

    Task<UserResponseDto> AddUser(UserRequestDto requestDto);

    Task<UserResponseDto> UpdateUser(Guid userId, UserRequestDto requestDto);

    Task DeleteUser(Guid userId);
}