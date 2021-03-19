using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V1.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
       
        public readonly  IRepository _repo ;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            
            
        }
        /// <summary>
        /// Método responsável por retornar todos os professores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }
        /// <summary>
        /// Método responsável por retornar apenas um único ProfessorDTO.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new ProfessorRegistrarDto());
        }

        /// <summary>
        /// Método responsável por retornar apenas um único Professor.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            
            if (professor == null) return BadRequest("O Professor não foi encontrado");
            var professorDto = _mapper.Map<ProfessorDto>(professor);
            return Ok(professorDto);
        }

        /// <summary>
        /// Método responsável por inserir o Professor.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var professor = _mapper.Map<Professor>(model);


            _repo.Add(professor);
       if(_repo.SaveChanges())
       {
           return Created($"/api/professor{model.Id}", _mapper.Map<ProfessorDto>(professor));
       }
        return BadRequest("Professor não Cadastrado.");
        }
        /// <summary>
        /// Método responsável por atualizar o cadastro do Professor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id, false);
             if(professor == null)return BadRequest("Professor não encontrado!");
            _mapper.Map(model, professor);

            _repo.Update(professor);
            if(_repo.SaveChanges())
            {
                return Created($"/api/professor{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Professor não atualizado");

            
        }

        /// <summary>
        /// Método responsável por atualizar o cadastro do Professor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id);
             if(professor == null)return BadRequest("Professor não encontrado!");
             _mapper.Map(model, professor);

              _repo.Update(professor);
            if(_repo.SaveChanges())
            {
                return Created($"/api/professor{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Professor não atualizado");
        }
        /// <summary>
        /// Método responsável por Exluir um cadastro de Professor do Banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             var professor = _repo.GetProfessorById(id);
             if(professor == null)return BadRequest("Professor não encontrado!");
             _repo.Delete(professor);

            if(_repo.SaveChanges())
            {
                return Ok("Professor deletado com sucesso");
            }
            return BadRequest("Professor não Deletado");

            
        }


    }
}