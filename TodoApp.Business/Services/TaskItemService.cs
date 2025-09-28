using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Business.Interfaces;
using TodoApp.DataAccess.Interfaces;
using TodoApp.Entities;

namespace TodoApp.Business.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        public TaskItemService(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            await _taskItemRepository.AddAsync(task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _taskItemRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _taskItemRepository.GetAllAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetCompletedTasksAsync()
        {
            return await _taskItemRepository.GetCompletedAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _taskItemRepository.GetByIdAsync(id);
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            await _taskItemRepository.UpdateAsync(task);
        }
    }
}
