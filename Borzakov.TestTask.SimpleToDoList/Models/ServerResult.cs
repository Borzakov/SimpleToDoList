using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borzakov.TestTask.SimpleToDoList.Models
{
    public class ServerResult
    {
        /// <summary>
        /// Предопределенный результат Success
        /// </summary>
        public static readonly ServerResult Success = new ServerResult();

        public ServerResult()
        {
        }
        /// <summary>
        /// Объект данных
        /// </summary>        
        public Object Data { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="errors">Массив ошибок</param>
        public ServerResult(params string[] errors)
        {
            this.Errors = errors;
        }
        /// <summary>
        /// Сообщение
        /// </summary>        
        public string Messages { get; private set; }
        /// <summary>
        /// Аггрегируемая ошибка
        /// </summary>        
        public String Error
        {
            get { return IsSuccess ? String.Empty : Errors.Aggregate((i, j) => i + Environment.NewLine + j); }
        }
        /// <summary>
        /// Коллекция ошибок
        /// </summary>        
        public IEnumerable<string> Errors { get; private set; }
        /// <summary>
        /// Признак отсутствия ошибок
        /// </summary>
        public bool IsSuccess => Errors == null || !Errors.Any();
        /// <summary>
        /// Признак наличия ошибок
        /// </summary>

        public bool HasError => Errors != null && Errors.Any();
        /// <summary>
        /// Добавление сообщений к объекту
        /// </summary>
        /// <param name="messages">Коллекция новых сообщений</param>
        public void SetMessages(params string[] messages)
        {
            Messages = messages.Aggregate((i, j) => i + Environment.NewLine + j);
        }
    }
}
