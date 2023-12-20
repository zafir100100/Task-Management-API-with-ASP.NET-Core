using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProcessingSystemDotnet.Interfaces;
using OrderProcessingSystemDotnet.Models;
using OrderProcessingSystemDotnet.Models.Tables;

namespace OrderProcessingSystemDotnet.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserTasksController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;

        public UserTasksController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        [HttpGet("get-all-task")]
        public async Task<IActionResult> GetTasks()
        {
            var response = await _userTaskService.GetTasks();
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("get-task-by-id")]
        public async Task<IActionResult> GetTask([FromBody] int id)
        {
            var response = await _userTaskService.GetTaskById(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("update-task")]
        public async Task<IActionResult> UpdateTask([FromBody] UserTask task)
        {
            var response = await _userTaskService.UpdateTask(task);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("create-task")]
        public async Task<IActionResult> CreateTask([FromBody] UserTask task)
        {
            var response = await _userTaskService.CreateTask(task);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("delete-task-by-id")]
        public async Task<IActionResult> DeleteTask([FromBody] int id)
        {
            var response = await _userTaskService.DeleteTask(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
