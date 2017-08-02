using Borzakov.TestTask.SimpleToDoList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borzakov.TestTask.SimpleToDoList.Services
{
    public class DbService : IDbService
    {
        private readonly SimpleToDoListContext _dbContext;

        public DbService(SimpleToDoListContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TaskToDo>> GetTaskList()
        {
            return await _dbContext.TaskToDo.OrderByDescending(i => i.TaskId).ToListAsync();
        }

        public async Task<int> AddTask(string taskText)
        {
            if(taskText == null)
            {
                throw new Exception("Task text for new record is null");
            }
            var newRecord = new TaskToDo()
            {
                Text = taskText,
                IsDone = false
            };
            _dbContext.TaskToDo.Add(newRecord);
            await _dbContext.SaveChangesAsync();
            return newRecord.TaskId;
        }

        public async Task CheckTask(int taskId)
        {
            var record = await _dbContext.TaskToDo.FirstOrDefaultAsync(i => i.TaskId == taskId);
            if(record == null)
            {
                throw new Exception("Record not found");
            }
            record.IsDone = !record.IsDone;
            await _dbContext.SaveChangesAsync();
        }
    }
}
