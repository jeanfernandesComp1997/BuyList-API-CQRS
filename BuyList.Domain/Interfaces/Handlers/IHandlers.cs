using System.Threading.Tasks;
using BuyList.Domain.Interfaces.Commands;

namespace BuyList.Domain.Interfaces.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<IResponse> Handle(T command);
    }
}