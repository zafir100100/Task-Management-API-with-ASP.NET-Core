# Task-Management-API-with-ASP.NET-Core

## Introduction

Task Management API with ASP.NET Core is a robust backend system designed for managing user tasks through API endpoints. This API facilitates the creation, retrieval, updating, and deletion of tasks, providing a comprehensive solution for task-related functionalities.

## Technology Stack

- ASP.NET Core
- C#
- Entity Framework Core
- Swagger (for API documentation)

## Features

1. **Get All Tasks**
   - **Endpoint:** `GET /api/v1/UserTasks/get-all-task`
   - **Description:** Retrieve a list of all tasks.

2. **Get Task by ID**
   - **Endpoint:** `POST /api/v1/UserTasks/get-task-by-id`
   - **Description:** Retrieve a task by its ID.
   - **Request Body:** `GetTaskDto` containing the task ID.

3. **Update Task**
   - **Endpoint:** `PATCH /api/v1/UserTasks/update-task`
   - **Description:** Update an existing task.
   - **Request Body:** `UserTask` representing the updated task.

4. **Create Task**
   - **Endpoint:** `POST /api/v1/UserTasks/create-task`
   - **Description:** Create a new task.
   - **Request Body:** `UserTask` representing the new task.

5. **Delete Task by ID**
   - **Endpoint:** `DELETE /api/v1/UserTasks/delete-task-by-id`
   - **Description:** Delete a task by its ID.
   - **Request Body:** `DeleteTaskRequestDto` containing the task ID.

## How to Run the Project

1. **Clone the Project:**
   ```bash
   git clone https://github.com/yourusername/task-management-api-dotnet.git
   ```

2. **Install Dependencies:**
   ```bash
   dotnet restore
   ```

3. **Run the API:**
   ```bash
   dotnet run
   ```

4. **Access Swagger Documentation:**
   Open your browser and navigate to `https://localhost:5001/swagger/index.html` to explore the API endpoints and test them interactively.

## Conclusion

The Task Management API with ASP.NET Core provides a solid foundation for handling task-related operations in a scalable and efficient manner. It leverages the power of ASP.NET Core, C#, and Entity Framework Core to deliver a reliable backend solution for task management.

Feel free to explore the API, run tests, and integrate it into your applications. If you have any questions or need further assistance, please contact me.
