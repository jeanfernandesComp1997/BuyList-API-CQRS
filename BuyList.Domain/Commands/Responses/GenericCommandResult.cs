using System;
using System.Threading.Tasks;
using BuyList.Domain.Interfaces.Commands;

namespace BuyList.Domain.Commands.Responses
{
    public class GenericCommandResult : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public GenericCommandResult() { }

        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static explicit operator GenericCommandResult(Task<IResponse> v)
        {
            throw new NotImplementedException();
        }
    }
}