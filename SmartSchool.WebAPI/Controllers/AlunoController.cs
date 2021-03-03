using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id =1,
                Nome = "Francisca",
                Sobrenome = "Gomes",
                Telefone = "789794546"

            },
            new Aluno(){
                Id =2,
                Nome = "Najara",
                Sobrenome = "Nascimento",
                Telefone = "45546464"

            },
            new Aluno(){
                Id =3,
                Nome = "Kenio",
                Sobrenome = "Roberto",
                Telefone = "7897494546"

            },
        };
        public AlunoController(){}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        //api/aluno/1
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a =>a.Id==id);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a=>a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome) );
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }


        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            
            return Ok(aluno);
        }

         [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            
            return Ok(aluno);
        }

         [HttpDelete]
        public IActionResult Delete(int id)
        {
            
            return Ok();
        }
    }
}