using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{   [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";

            return Ok(student);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudentById([FromRoute] int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }
            else if (id == 3)
            {
                return Ok("Andrzejewski");
            }

            return NotFound($"Nie znaleziono studenta o id {id}");

        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateStudent([FromRoute] int id)
        {
            return Ok("Aktualizacja dokończona");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent([FromRoute] int id)
        {
            return Ok("Usuwanie ukończone");
        }
    }
}
