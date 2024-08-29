using Reservei_API.Services.Interfaces;
using Microsoft.AspNetCore;
using Reservei_API.Objects.DTOs.Entities;
using Reservei_API.Objects.Contracts;
using Reservei_API.Objects.Utilities;
using System.Dynamic;
using System.ComponentModel.DataAnnotations;

namespace Reservei_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly Response _response;

        public UserController(IUserService userService)
        {
            _userService = userService;
            _response = new Response();
        }
        [HttpGet("GetAll")]

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            try
            {
                var usersDTO = await _userService.GetAll();
                _response.SetSuccess();
                _response.Message = usersDTO.Any() ?
                    "Lista do(s) Usuarios(s) obtida com sucesso." :
                    "Nenhum Usuário encontrado. ";
                _response.Data = usersDTO;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.SetError();
                _response.Message = "Nao foi possivel adquirir a lista do(s) usuarios!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
            [HttpGet("GetById/{id:int}")]
            public 
        }
    }
}
