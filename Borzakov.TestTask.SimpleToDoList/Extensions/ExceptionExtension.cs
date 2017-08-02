using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borzakov.TestTask.SimpleToDoList.Extensions
{
    public static class ExceptionExtension
    {
        public static string GetAggregateException(this Exception ex)
        {
            var exception = ex as AggregateException;
            if (exception != null)
            {
                var sb = new StringBuilder();
                var agg = exception;
                foreach (var innerEx in agg.InnerExceptions)
                {
                    sb.AppendLine(innerEx.GetAggregateException());
                }
                return sb.ToString();
            }
            else
            {
                if (ex.InnerException == null)
                    return ex.Message;
                var sb = new StringBuilder();
                sb.AppendLine(ex.Message);
                sb.AppendLine(ex.InnerException.GetAggregateException());
                return sb.ToString();
            }
        }
    }
}
