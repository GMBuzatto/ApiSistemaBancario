using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Application.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")] // notations
        [MaxLength(200, ErrorMessage = "O Nome não pode ter mais de 200 caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O Cpf é obrigatório")]
        [MaxLength(11, ErrorMessage = "O Cpf deve ter 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")] // notations
        [MaxLength(100, ErrorMessage = "O E-mail não pode ter mais de 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Número de Celular é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Número de Celular deve ter 100 caracteres")]
        public string NumeroCelular { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Estado deve ter no máx 100 caracteres")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatório")]
        [MaxLength(100, ErrorMessage = "a Cidade deve ter no máx 100 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Bairro deve ter no máx 100 caracteres")]
        public string Bairro { get; set; }


        [Required(ErrorMessage = "O Endereço é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Endereço deve ter no máx 100 caracteres")]
        public string Endereco { get; set; }


        [Required(ErrorMessage = "O Número é obrigatório")]
        [MaxLength(10, ErrorMessage = "O Número deve ter no máx 10 caracteres")]
        public string Numero { get; set; }


        [Required(ErrorMessage = "A senha é obrigatório")] // notations
        [MaxLength(100, ErrorMessage = "A Senha não pode ter mais de 100 caracteres")]
        [MinLength(8, ErrorMessage = "A Senha não pode ter menos de 8 caracteres")]
        [NotMapped]// notations que avisa que o password não precisa ser mappeado, pois na classe original não possui no construtor

        public string Password { get; set; }
    }
}
