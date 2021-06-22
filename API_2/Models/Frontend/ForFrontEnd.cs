using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2.Models.Frontend
{
    public class ForFrontEnd<T>
    {
        public T Data { get; set; }
        public bool State { get; set; }
        public string Message { get; set; }

        public Exception Exception
        {
            #if RELEASE
                private get;
            #else
                get;
            #endif
                set;
        }

        public ForFrontEnd()
        {
        }
        public ForFrontEnd(T data, bool state, string message, Exception exception)
        {
            Data = data;
            State = state;
            Message = message;
            Exception = exception;
        }

        public static ForFrontEnd<T> True(T data)
        {
            return new ForFrontEnd<T>(data, true, "", null);
        }
        public static ForFrontEnd<T> False(T data, string message, Exception exception)
        {
            return new ForFrontEnd<T>(data, false, message, exception);
        }
    }
}
