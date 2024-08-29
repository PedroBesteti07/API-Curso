using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservei_API.Services.Interfaces
{
    public class IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();

        Task<UserDTO> GetById(int id);

        Task<UserDTO> Create(UserDTO userDTO);

        Task<UserDTO> Update(UserDTO userDTO);

        Task<UserDTO> Delete(UserDTO userDTO);
    }
}
