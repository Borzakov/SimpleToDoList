using Borzakov.TestTask.SimpleToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borzakov.TestTask.SimpleToDoList.Services
{
    public interface IDbService
    {
        /// <summary>
        /// Возвращает список всех задач
        /// </summary>
        /// <returns>Список задач<see cref="TaskToDo"/></returns>
        Task<List<TaskToDo>> GetTaskList();
        /// <summary>
        /// Добавляет новую задачу с указанным текстом
        /// </summary>
        /// <param name="taskText">Текст новой задачи</param>
        /// <returns>Идентификатор новой задачи<see cref="int"/></returns>
        Task<int> AddTask(string taskText);
        /// <summary>
        /// Переключает состояние задачи
        /// </summary>
        /// <param name="taskId">Идентификатор задачи</param>
        Task CheckTask(int taskId);
    }
}
