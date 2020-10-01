using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SGE.DataAccess.Builders;
using SGE.DataAccess.Dtos;
using SGE.DataAccess.Entities;
using SGE.DataAccess.Types;

namespace SGE.WebApi.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IMapper _mapper;
        public ValuesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("user")]
        public ActionResult<object> ConvertUserType([FromBody] UserDto userDto)
        {

            try
            {
                var user = new UserBuilder()
                            .AddName(userDto.Name)
                            .AddSurname(userDto.Surname)
                            .AddCpf(userDto.Cpf)
                            .AddEmail(userDto.Email)
                            .Build();

                return Ok(user);
            }

            catch(Exception)
            {
                return BadRequest("Bad request");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
