using AutoMapper;
using AutoMapper.QueryableExtensions;
using DependencyInjection.BusinessLayer.Dtos;
using DependencyInjection.BusinessLayer.Interfaces;
using DependencyInjection.Data.Repositories.Interfaces;
using DependencyInjection.Entities.Users;
using DependencyInjection.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjection.BusinessLayer.Services.Users;

internal class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    #region IUserService Members

    public async Task<IReadOnlyCollection<UserResponseDto>> GetUsers()
    {
        return await _userRepository.GetAll()
                                    .ProjectTo<UserResponseDto>(_mapper.ConfigurationProvider)
                                    .ToArrayAsync();
    }

    public async Task<UserResponseDto> GetUser(Guid userId)
    {
        var user = await _userRepository.GetById(userId);
        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task<UserResponseDto> AddUser(UserRequestDto requestDto)
    {
        if (await _userRepository.GetAll().AnyAsync(q => q.Email == requestDto.Email))
        {
            throw new ObjectExistsException($"User with email {requestDto.Email}");
        }

        var user = _mapper.Map<User>(requestDto);
        await _userRepository.Add(user);

        await _userRepository.Save();

        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task<UserResponseDto> UpdateUser(Guid userId, UserRequestDto requestDto)
    {
        var user = await _userRepository.GetById(userId);
        if (user is null)
        {
            throw new ObjectNotFoundException("User");
        }

        _mapper.Map(requestDto, user);

        await _userRepository.Save();

        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task DeleteUser(Guid userId)
    {
        await _userRepository.Delete(userId);
        await _userRepository.Save();
    }

    #endregion
}