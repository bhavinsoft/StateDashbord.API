using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class Result<T>
    {
        public bool sucess { get; set; }
        public int sucess_code { get; set; }
        public T data { get; set; }
        public string message { get; set; }


        public static Result<T> SuccessResult( T data, string message, int sucess_code=1) => new Result<T> { sucess = true, message = message, sucess_code = sucess_code, data = data };
        public static Result<T> FailureResult(string message, int sucess_code=0) => new Result<T> { sucess = false,message =message, sucess_code = sucess_code};
    }
}
