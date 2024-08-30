
using System.ComponentModel.DataAnnotations;

namespace ReserveiAPI.Objects.DTO_s.Entities
{
    public class UserDTO
    {

        public int Id { get; set; }

        public string? ImageUser { get; set; }

        [Required(ErrorMessage = "O nome é requirido")]
        [MaxLength(100)]
        public string NameUser { get; set; }

        [Required(ErrorMessage = "o e-mail é requerido")]
        [MinLength(10)]
        [MaxLength(100)]
        public string EmailUser
        {
            get => _emailUser;
            set => _emailUser = value.ToLower();
        }

        public string _emailUser { get; set; }

        [Required(ErrorMessage = "A senha é requerida")]
        [MinLength(8)]
        public string PasswordUser { get; set; }

        [Required(ErrorMessage = "O telefone é requerido")]
        [MinLength(14)]
        [MaxLength(15)]
        public string PhoneUser { get; set; }

    }
}