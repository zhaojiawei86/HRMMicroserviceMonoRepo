using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Hrm.Recruitment.ApplicationCore.Contract.Service;
using Hrm.Recruitment.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hrm.Recruitment.APILayer.Controller

{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequirementController : ControllerBase
    {
        private readonly IJobRequirementServiceAsync jobRequirementServiceAsync;

        public JobRequirementController(IJobRequirementServiceAsync _jobRequirementServiceAsync)
        {
            jobRequirementServiceAsync = _jobRequirementServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await jobRequirementServiceAsync.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await jobRequirementServiceAsync.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest(item);
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post(JobRequirementRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await jobRequirementServiceAsync.InsertAsync(model);
                return Ok();
            }
            return BadRequest(model);
        }

        [HttpPut]
        public async Task<IActionResult> Put(JobRequirementRequestModel model, int id)
        {
            model.Id = id;
            var item = await jobRequirementServiceAsync.UpdateAsync(model);
            if (item == 0)
            {
                return BadRequest(item);
            }
            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await jobRequirementServiceAsync.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest(item);
            }
            await jobRequirementServiceAsync.DeleteAsync(id);
            return Ok(item);
        }
    }
}