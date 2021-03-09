using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         bool SaveChanges();

        //Alunos
        Aluno[] GetAllAlunos(bool includePrefessor = false);
        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includePrefessor = false);
        Aluno GetAlunoById(int alunoId, bool includePrefessor = false);

         //Professores
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false);
        Professor GetProfessorById(int professorId, bool includeProfessor = false);


         

    }
}