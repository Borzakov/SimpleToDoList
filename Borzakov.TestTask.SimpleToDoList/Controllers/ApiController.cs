using Borzakov.TestTask.SimpleToDoList.Extensions;
using Borzakov.TestTask.SimpleToDoList.Models;
using Borzakov.TestTask.SimpleToDoList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borzakov.TestTask.SimpleToDoList.Controllers
{
    public class ApiController : Controller
    {
        private readonly ILogger _logger;
        private readonly IDbService _dbService;

        public ApiController(IDbService dbService, ILogger<ApiController> logger)
        {
            _dbService = dbService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ServerResult> GetTaskList()
        {
            try
            {
                return new ServerResult()
                {
                    Data = await _dbService.GetTaskList()
                };
            }
            catch (Exception e)
            {
                string temp = e.GetAggregateException();
                _logger.LogError(temp);
                return new ServerResult(temp);
            }
        }

        [HttpPost]
        public async Task<ServerResult> AddTask([FromBody] TaskToDo taskText)
        {
            try
            {
                return new ServerResult()
                {
                    Data = await _dbService.AddTask(taskText.Text)
                };
            }
            catch (Exception e)
            {
                string temp = e.GetAggregateException();
                _logger.LogError(temp);
                return new ServerResult(temp);
            }
        }

        [HttpPost]
        public async Task<ServerResult> CheckTask([FromBody]int taskId)
        {
            try
            {
                await _dbService.CheckTask(taskId);
                return new ServerResult();
            }
            catch (Exception e)
            {
                string temp = e.GetAggregateException();
                _logger.LogError(temp);
                return new ServerResult(temp);
            }
        }
    }
}
