using Reservei_API.Objects.DTOs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservei_API.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();

        Task<UserDTO> GetById(int id);

        Task<UserDTO> Create(UserDTO userDTO);

        Task<UserDTO> Update(UserDTO userDTO);

        Task<UserDTO> Delete(UserDTO userDTO);
    }
}
