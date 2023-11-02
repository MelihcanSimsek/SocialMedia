using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data,string message):base(message,data,false)
        {
            
        }

        public ErrorDataResult(T data):base(data,false)
        {
            
        }

        public ErrorDataResult():base(default,false)
        {
            
        }

        public ErrorDataResult(string message):base(message,default,false)
        {
            
        }
    }
}
