using SistemaBancario.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string NumeroCelular { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Endereco { get; private set; }
        public string Numero {  get; private set; }

        //segurança para estar salvando em byte a senha
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

        //depois implementar aqui vinculo dos cartões
        //..


        //construtor com ID
        public Usuario(int id,string nome, string cpf, string email, string numeroCelular, string estado, string cidade, string bairro, string endereco, string numero)
        {
            DomainExceptionValidation.When(id < 0, "O Id do Cliente deve ser maior que 0");
            Id = id;
            ValidateDomain(nome, cpf, email, numeroCelular, estado, cidade, bairro, endereco, numero);
        }

        //construtor sem ID
        public Usuario(string nome, string cpf, string email, string numeroCelular, string estado, string cidade, string bairro, string endereco, string numero)
        {
            ValidateDomain(nome, cpf, email, numeroCelular, estado, cidade, bairro, endereco, numero);
        }



        //método para permitir alteração dos atributos 
        public void Update(string nome, string cpf, string email, string numeroCelular, string estado, string cidade, string bairro, string endereco, string numero)
        {
            ValidateDomain(nome,cpf,email,numeroCelular,estado,cidade,bairro,endereco,numero);
        }

        public void AlterarSenha(byte[] paswordHash, byte[] passwordSalt)
        {
            PasswordHash = paswordHash;
            PasswordSalt = passwordSalt;
        }

        //validação do construtor
        public void ValidateDomain(string nome, string cpf, string email,  string numeroCelular, string estado, string cidade, string bairro, string endereco, string numero)
        {
            DomainExceptionValidation.When(nome.Length > 200, "O Nome deve ter, no máximo 200 caracteres");
            DomainExceptionValidation.When(cpf.Length != 11, "O CPF Deve ter, 11 caracteres");
            DomainExceptionValidation.When(email.Length > 100, "O Email deve ter, no máxiomo 200 caracteres");
            DomainExceptionValidation.When(numeroCelular.Length != 11, "O Número de celular deve ter, 11 caracteres");
            DomainExceptionValidation.When(estado.Length > 100, "O Estado deve ter, no máximo 100 caracteres");
            DomainExceptionValidation.When(cidade.Length > 100, "A Cidade deve ter, no máximo 100 caracteres");
            DomainExceptionValidation.When(bairro.Length > 100, "O Bairro deve ter, no máximo 100 caracteres");
            DomainExceptionValidation.When(endereco.Length > 100, "O Endereço deve ter, no máximo 100 caracteres");
            DomainExceptionValidation.When(numero.Length > 10, "O Número deve ter, no máximo 10 caracteres");


            Nome = nome;
            Cpf = cpf;
            Email = email;
            NumeroCelular = numeroCelular;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Endereco = endereco;
            Numero = numero;
        }

    }
}
