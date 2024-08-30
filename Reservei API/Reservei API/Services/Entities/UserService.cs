using AutoMapper;
using Reservei_API.Objects.Contracts;
using Reservei_API.Objects.DTOs.Entities;
using Reservei_API.Objects.Models.Entities;
using Reservei_API.Repositories.Interfaces;
using Reservei_API.Services.Interfaces;

namespace Reservei_API.Services.Entities
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var usersModel = await _userRepository.GetAll();

            usersModel.ToList().ForEach(u => u.PasswordUser = "");
            return _mapper.Map<IEnumerable<UserDTO>>(usersModel);
        }
        public async Task<UserDTO> GetById(int id)
        {
            var usersModel = await _userRepository.GetById(id);

            if (usersModel is not null) usersModel.PasswordUser = "";
            return _mapper.Map<UserDTO>(usersModel);
        }
        public async Task Create(UserDTO userDTO)
        {
            var userModel = _mapper.Map<UserModel>(userDTO);
            await _userRepository.Create(userModel);

            userDTO.Id = userModel.Id;
            userDTO.PasswordUser = "";
        }
        public async Task Update(UserDTO userDTO)
        {
            var userModel = _mapper.Map<UserModel>(userDTO);
            await _userRepository.Update(userModel);

            userModel.PasswordUser = "";
        }
        public async Task Delete(UserDTO userDTO)
        {
            var userModel = _mapper.Map<UserModel>(userDTO);
            await _userRepository.Delete(userModel);

            userDTO.PasswordUser = "";
        }
    }
}
