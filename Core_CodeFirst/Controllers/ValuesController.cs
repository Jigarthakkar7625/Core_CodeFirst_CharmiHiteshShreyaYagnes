using AutoMapper;
using Core_CodeFirst.Data.Models;
using Core_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        private readonly TestDbmajwtContext _contextAccessor;
        private readonly IMapper _mapper;

        public ValuesController(TestDbmajwtContext testDbmajwtContext, IMapper mapper)
        {
            _contextAccessor = testDbmajwtContext;
            _mapper = mapper;
        }


        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {


            int a = 0;
            int result = 10 / a;

            List<Employee> employees = _contextAccessor.Employees.ToList();

            List<EmployeeDTO> EmployeeDTO = _mapper.Map<List<EmployeeDTO>>(employees);

           Employee employees1 = _contextAccessor.Employees.FirstOrDefault();

            EmployeeDTO EmployeeDTO1 = _mapper.Map<EmployeeDTO>(employees1);


            return Ok(EmployeeDTO1);
        
        }

            //// GET: api/<ValuesController>
            //[HttpGet]
            //public IEnumerable<string> Get()
            //{
            //    return new string[] { "value1", "value2" };
            //}

            // GET api/<ValuesController>/5
        //    [HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            // 98 >> Time taking ya to Error  ?
            await _contextAccessor.Employees.ToListAsync(); // 98
            return Ok();
        }

        [HttpDelete("{id}")]
        public object Delete123(int id)
        {
            // 98 >> Time taking ya to Error  ?
            _contextAccessor.Employees.ToListAsync(); // 98
            return Ok();
        }

        // Async and Await : 

        // Sync and Async
    }
}
