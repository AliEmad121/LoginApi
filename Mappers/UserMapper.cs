using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMappers 
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age
            };
        }



    }
}