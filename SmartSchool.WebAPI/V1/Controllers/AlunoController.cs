using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V1.Dtos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace SmartSchool.WebAPI.V1.Controllers
{
    /// <summary>
    /// Versao 1 do meu controlador de alunos
    /// </summary>

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {

        
        public readonly IRepository _repo;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        /// <summary>
        /// Método respons´svel para retornar todos os meus alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
            
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }
        /// <summary>
        /// Método responsável por retornar apenas um único AlunoDTO.
        /// </summary>
        /// <returns></returns>
         [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new AlunoRegistrarDto());
        }

        /// <summary>
        /// Método responsável por retornar apenas um único Aluno.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //api/aluno/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            var alunoDto = _mapper.Map<AlunoDto>(aluno);
            return Ok(alunoDto);
        }


        /// <summary>
        /// Método responsável por inserir aluno.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não Cadastrado.");
        }

        /// <summary>
        /// Método responsável por atualizar.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado!");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não Atualizado.");
        }
        /// <summary>
        /// Método responsável por Atualizar.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado!");
            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não Atualizado.");
        }
        /// <summary>
        /// Método responsável por Exluir aluno.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado!");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno Deletado");
            }
            return BadRequest("Aluno não deletado.");
        }
    }
}