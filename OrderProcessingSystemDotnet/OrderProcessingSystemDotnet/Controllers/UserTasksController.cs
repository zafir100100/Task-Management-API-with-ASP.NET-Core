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

        // GET: api/UserTasks/get-all-task
        [HttpGet("get-all-task")]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetTasks()
        {
            // Fetch tasks using the injected service
            var response = await _userTaskService.GetTasks();

            // Return the response with the appropriate status code
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/UserTasks/get-task?id={id}
        [HttpGet("get-task")]
        public async Task<ActionResult<ResponseDto>> GetTask([FromBody] int id)
        {
            // TODO: Implement the logic to get a task by ID
            // Documentation: Retrieves a task by the specified ID from the database.

            // Sample code (replace with actual implementation)
            var response = await _userTaskService.GetTaskById(id);

            // Return the response with the appropriate status code
            return StatusCode(response.StatusCode, response);
        }

        // PUT: api/UserTasks/put-task?id={id}
        [HttpPut("put-task")]
        public async Task<ActionResult<ResponseDto>> PutTask([FromBody] UserTask task)
        {
            // TODO: Implement the logic to update a task by ID
            // Documentation: Updates an existing task with the specified ID in the database.

            // Sample code (replace with actual implementation)
            var response = await _userTaskService.UpdateTask(task);

            // Return the response with the appropriate status code
            return StatusCode(response.StatusCode, response);
        }

        // POST: api/UserTasks/post-task
        [HttpPost("post-task")]
        public async Task<ActionResult<ResponseDto>> PostTask([FromBody] UserTask task)
        {
            // TODO: Implement the logic to create a new task
            // Documentation: Creates a new task with the provided details in the database.

            // Sample code (replace with actual implementation)
            var response = await _userTaskService.CreateTask(task);

            // Return the response with the appropriate status code
            return StatusCode(response.StatusCode, response);
        }

        // DELETE: api/UserTasks/delete-task?id={id}
        [HttpDelete("delete-task")]
        public async Task<ActionResult<ResponseDto>> DeleteTask([FromBody] int id)
        {
            // TODO: Implement the logic to delete a task by ID
            // Documentation: Deletes an existing task with the specified ID from the database.

            // Sample code (replace with actual implementation)
            var response = await _userTaskService.DeleteTask(id);

            // Return the response with the appropriate status code
            return StatusCode(response.StatusCode, response);
        }
    }
}
