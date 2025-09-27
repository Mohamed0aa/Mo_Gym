using Mo_Talabat_Core_Domain.Common.Dtos;

namespace Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfUser
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(int userId);
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUserDto);
        Task<bool> DeleteUserAsync(int userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<bool> VerifyPhoneAsync(int userId);
        Task<bool> VerifyEmailAsync(int userId);
    }
}
