using Microsoft.AspNetCore.Mvc;
using Academy.Application.Services;
using Academy.Infrastructure.Context;
using Academy.Infrastructure.Data.Repository;
using Academy.Application.Interfaces;
using Academy.Domain.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<List<Student>>Get()
        {
            var response = _studentService.GetList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var response = _studentService.GetEntity(id);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Student student)
        {
            _studentService.Add(student);
            return Ok("Estudiante agregado con éxito");
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Student student)
        {
            _studentService.Edit(student);
            return Ok("Estudiante modificado con éxito");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _studentService.Delete(id);
            return Ok("Estudiante eliminado con éxito");
        }
    }
}
