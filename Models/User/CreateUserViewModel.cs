using System.ComponentModel.DataAnnotations;

namespace DreamCash.Models
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Favor inserir o nomme do usuário!")]
        [MinLength(3, ErrorMessage = "Favor inserir um nome com pelo menos três caracteres!")]
        [MaxLength(20, ErrorMessage = "Favor inserir um nome com até vinte caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Favor inserir o documento do usuário!")]
        [MinLength(11, ErrorMessage = "Favor inserir CPF com no mínimo 11 dígitos!")]
        [MaxLength(11, ErrorMessage = "Favor inserir CPF com no máximo 11 dígitos!")]
        public string Document { get; set; }

        [Required(ErrorMessage = "Favor inserir o e-mail do usuário!")]
        [MinLength(3)]
        [MaxLength(20)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Favor inserir a senha do usuário!")]
        [MinLength(3)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Favor inserir um telefone do usuário!")]
        [MinLength(3, ErrorMessage = "Favor inserir uma senha com pelo menos três caracteres!")]
        [MaxLength(20, ErrorMessage = "Favor inserir uma senha com o máximo de vinte caracteres!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Favor inserir a data de nascimento do usuário!")]
        [MinLength(3)]
        [MaxLength(20)]
        public string Birthday { get; set; }

        [Required(ErrorMessage = "Favor inserir o sexo do usuário!")]
        [MinLength(3)]
        [MaxLength(20)]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Favor inserir o endereço do usuário!")]
        [MinLength(3)]
        [MaxLength(20)]
        public string Address { get; set; }
    }
}