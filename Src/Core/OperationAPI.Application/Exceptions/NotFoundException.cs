using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Exceptions
{
  public class NotFoundException : Exception
    {
        public NotFoundException(string? message, object key) : base($"{message!.Substring(0, message.Length - 6)} Object {key} was not found")
        {

        } 
    }
}
