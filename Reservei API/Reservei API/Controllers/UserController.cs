using Reservei_API.Services.Interfaces;
using Microsoft.AspNetCore;
using Reservei_API.Objects.Contracts;
using Reservei_API.Objects.Utilities;
using System.Dynamic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ReserveiAPI.Objects.DTO_s.Entities;
using System.Runtime.CompilerServices;

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
                _response.Data = new { ErrorMessage = ex.Message,StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
            [HttpGet("GetById/{id:int}")]
            public async Task<ActionResult<UserDTO>> Delete(int id)
            {
                try
                {
                    var userDTO = await _userService.GetById(id);
                    if(userDTO is null)
                    {
                        _response.SetNotFound();
                        _response.Message = "Dado com conflito";
                        _response.Data = new { errorId = "Usuario não encontrado" };
                        return NotFound(_response);
                    }
                    await _userService.Delete(userDTO);

                    _response.SetSuccess();
                    _response.Message = "Usuario" + userDTO.NameUser + "excluido com sucesso.";
                    _response.Data = userDTO;
                    return Ok(_response);
                }
                catch(Exception ex)
                {
                    _response.SetError();
                    _response.Message = "Não foi possivel excluir o Usuário";
                    _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace avaiable!"};
                    return StatusCode(StatusCodes.Status500InternalServerError, _response);
                }
            }
            private static void CheckDatas(UserDTO userDTO, ref dynamic errors, ref bool hasErrors)
            {
                if(!ValidatorUtilitie.CheckValidPhone(userDTO.PhoneUser))
                {
                    errors.errorPhoneUser = "Numero invalido!";
                    hasErrors = true;
                }
                int status = ValidatorUtilitie.CheckValidEmail(userDTO.EmailUser);
                if (status == -1)
                {
                    errors.errorEmailUser = "Email invalido";
                    hasErrors = true;
                }
                else if(status == -2)
                {
                    errors.errorEmailUser = "Dominio invalido!";
                    hasErrors = true;

                }
            }
            private static void CheckDuplicates(IEnumerable<UserDTO> usersDTO, UserDTO userDTO, ref dynamic errors, ref bool hasErrors)
            {
                foreach(var user in usersDTO)
                {
                    if(userDTO.Id == user.Id)
                    {
                        continue;
                    }
                    if(ValidatorUtilitie.CompareString(userDTO.EmailUser, user.EmailUser))
                    {
                        errors.erroredEmailUser = "O e-mail" + userDTO.EmailUser + "já está sendo utilizado!";
                        hasErrors = true;

                        break;
                    }
                }
            }
        }
    }
}
