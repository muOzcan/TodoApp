using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Entities;

namespace TodoApp.DataAccess.Interfaces
{
    public interface ITaskItemRepository : IGenericRepository<TaskItem>
    {
        Task<IEnumerable<TaskItem>> GetCompletedAsync();
        
    }
}
