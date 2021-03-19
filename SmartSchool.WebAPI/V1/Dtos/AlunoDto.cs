using System;
namespace SmartSchool.WebAPI.V1.Dtos
{
    /// <summary>
    /// Este e o AlunoDTO
    /// </summary>
    public class AlunoDto
    {
        /// <summary>
        /// Identificador e chave do banco de dados.
        /// </summary>
         public int Id { get; set; }
        /// <summary>
        /// Chave do aluno para outros neg�cios na institui��o.
        /// </summary>
        public int Matricula { get; set; }
        /// <summary>
        /// Primeiro nome e o Sobrenome do aluno
        /// </summary>
        public string Nome { get; set; }

        public string Telefone { get; set; }
        /// <summary>
        /// Esta idade � p calculo relacionado a data de nascimento do aluno.
        /// </summary>
        public int Idade { get; set; }
        /// <summary>
        /// Data preenchida pelo dia do cadastro
        /// </summary>
        public DateTime DataIni { get; set; } 

        /// <summary>
        /// Se o aluno esta ativo ou nao na institui��o
        /// </summary>
        public bool Ativo { get; set; } 
        
    }
}