using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_do_list.Data.DTO;
using To_do_list.Data.Entities.Enums;
using To_do_list.Services.IServices;

namespace To_do_list.Controllers
{
    [Route("api/issue")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _service;
        public IssueController(IIssueService service) { 
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddIssue([FromBody] AddTextDTO textDTO)
        {
            await _service.AddIssue(textDTO);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteIssue([FromBody] DeleteIssueDTO deleteIssueDTO)
        {
            await _service.DeleteIssue(deleteIssueDTO);
            return Ok();
        }

        [HttpPatch("edit")]
        public async Task<IActionResult> EditIssue([FromBody] EditIssueDTO editIssueDTO)
        {
            await _service.EditIssue(editIssueDTO);
            return Ok();
        }

        [HttpGet("get/issues")]
        public async Task<ActionResult<List<IssueDTO>>> GetAllIssues()
        {
           var result = await _service.GetAllIssues();
            return Ok(result);
        }

        [HttpPatch("change/status")]
        public async Task<IActionResult> ChangeStatus([FromQuery]Guid id, Statuses status)
        {
            await _service.ChangeStatus(id, status);
            return Ok();
        }

        [HttpPost("replace")]
        public async Task<IActionResult> ReplaceAllIssues([FromBody] List<AddIssuesListDTO> newIssues)
        {
            await _service.ReplaceAllIssues(newIssues);
            return Ok();
        }
    }
}
