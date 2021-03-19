using System;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.V1.Dtos
{
    /// <summary>
    /// Este � o DTO de aluno para Registrar.
    /// </summary>
    public class AlunoRegistrarDto
    {
        /// <summary>
        /// Identificador e chave primaria no banco de dados.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Matricula e identificador na institui��o.
        /// </summary>
        public int Matricula { get; set; }
        /// <summary>
        /// Nome do aluno .
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Sobrenome do aluno.
        /// </summary>
        public string Sobrenome { get; set; }
        /// <summary>
        /// Telefone de contato do aluno .
        /// </summary>
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        /// <summary>
        /// Se esta ativo ou nao 
        /// </summary>
        public bool Ativo { get; set; } = true;
      

    }
}