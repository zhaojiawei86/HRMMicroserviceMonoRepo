using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hrm.Interview.ApplicationCore.Contract.Service;
using Hrm.Interview.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hrm.Interview.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerServiceAsync interviewerServiceAsync;

        public InterviewerController(IInterviewerServiceAsync _interviewerServiceAsync)
        {
            interviewerServiceAsync = _interviewerServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await interviewerServiceAsync.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await interviewerServiceAsync.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest(item);
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InterviewerRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewerServiceAsync.InsertAsync(model);
                return Ok();
            }
            return BadRequest(model);
        }

        [HttpPut]
        public async Task<IActionResult> Put(InterviewerRequestModel model, int id)
        {
            model.Id = id;
            var item = await interviewerServiceAsync.UpdateAsync(model);
            if (item == 0)
            {
                return BadRequest(item);
            }
            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await interviewerServiceAsync.DeleteAsync(id);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
