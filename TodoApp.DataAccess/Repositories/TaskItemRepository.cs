using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DataAccess.Context;
using TodoApp.DataAccess.Interfaces;
using TodoApp.Entities;

namespace TodoApp.DataAccess.Repositories
{
    public class TaskItemRepository : GenericRepository<TaskItem>, ITaskItemRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TaskItem>> GetCompletedAsync()
        {
            return await _context.TaskItems.Where(t => t.IsCompleted).ToListAsync();
        }
    }
}
