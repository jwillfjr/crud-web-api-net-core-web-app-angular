using ExampleCRUD.Application.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleCRUD.WebService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        public virtual async Task<ActionResult> Post(Domain.Entities.User model)
        {
            try
            {
                return Ok(await _userAppService.Add(model));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult> Put(Domain.Entities.User model)
        {
            try
            {
                return Ok(await _userAppService.Update(model));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual async Task<ActionResult> Delete(long id)
        {
            try
            {
                return Ok(await _userAppService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<ActionResult> Get(long id)
        {
            try
            {
                return Ok(await _userAppService.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("getbynameorcpfcnpj")]
        public virtual async Task<ActionResult> GetByNameOrCpfCnpj(string nameorcpfcnpj, int page, int resultsPerPage)
        {
            try
            {
                return Ok(await _userAppService.GetByNameOrCpfCnpj(nameorcpfcnpj, page, resultsPerPage));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
