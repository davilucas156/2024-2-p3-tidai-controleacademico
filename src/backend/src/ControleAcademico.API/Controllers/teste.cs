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
    public class teste : ControllerBase
    {
        [HttpGet]
        public NewClass get(){
            return new NewClass();
        }
        [HttpGet]
        public string put(){
            return "Testes de vdd";
        }

        [HttpGet("{id}")]
        public string get(int id){
            return $"Testes de vdd {id}";
        }
    }
}