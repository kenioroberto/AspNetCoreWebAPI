using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Curso
    {
        public Curso() { }
        public Curso(int id, string nome)
        {
            this.id = id;
            this.Nome = nome;

        }
        public int id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Disciplina> Disciplina { get; set; }
    }
}