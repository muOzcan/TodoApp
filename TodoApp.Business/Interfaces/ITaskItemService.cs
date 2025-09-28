using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Entities;

namespace TodoApp.Business.Interfaces
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem?> GetTaskByIdAsync(int id);
        Task AddTaskAsync(TaskItem task);
        Task UpdateTaskAsync(TaskItem task);
        Task DeleteTaskAsync(int id);
        Task<IEnumerable<TaskItem>> GetCompletedTasksAsync();
    }
}
