using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hrm.Recruitment.ApplicationCore.Contract.Service;
using Hrm.Recruitment.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hrm.Recruitment.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateServiceAsync candidateServiceAsync;

        public CandidateController(ICandidateServiceAsync _candidateServiceAsync)
        {
            candidateServiceAsync = _candidateServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await candidateServiceAsync.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await candidateServiceAsync.GetByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CandidateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await candidateServiceAsync.InsertAsync(model);
                return Ok(model);
            }
            return BadRequest(model);

        }

        [HttpPut]
        public async Task<IActionResult> Put(CandidateRequestModel model, int id)
        {
            model.Id = id;
            var item = await candidateServiceAsync.UpdateAsync(model);
            if (item == 0)
            {
                return BadRequest();
            }
            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await candidateServiceAsync.GetByIdAsync(id);
            if (item != null)
            {
                await candidateServiceAsync.DeleteAsync(id);
                return Ok();
            }
            return BadRequest(item);
        }
    }
}

