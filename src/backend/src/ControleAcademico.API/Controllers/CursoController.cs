using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ControleAcademico.API.Model;

namespace ControleAcademico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ControleAcademicoContext _context;
        public CursoController(ControleAcademicoContext context)
        {
            this._context = context;
            
        }

        [HttpGet]
        public IEnumerable<Curso> GetCursos(){
            return _context.Cursos;
        }

        [HttpGet("{id}")]
        public Curso GetCursos( int id){
            return _context.Cursos.FirstOrDefault(aux=>aux.IdCursos==id);
        }


        [HttpPost]
        public IEnumerable<Curso> postCursos(Curso curso){
            _context.Cursos.Add(curso);
            if(_context.SaveChanges() > 0)
                return _context.Cursos;
            else
                throw new Exception("A inclusão não foi realizada");
        }

        [HttpPut("{id}")]
        public Curso PutCursos( int id, Curso curso){
            if(curso.IdCursos != id) throw new Exception ("Você  está tentadno atualizar a atividade errada");
            _context.Update(curso);

            if(_context.SaveChanges() > 0)
                return _context.Cursos.FirstOrDefault(aux=>aux.IdCursos==id);
            else 
                return new Curso();
        }


        [HttpDelete("{id}")]
        public bool DeleteCursos( int id){
            var curso= _context.Cursos.FirstOrDefault(aux=>aux.IdCursos==id);
            if(curso==null)
                throw new Exception ("Voce está tentando deletar um curso que não existe");
            
            _context.Remove(curso);

            return _context.SaveChanges() > 0;
        }

    }
}