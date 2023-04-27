using System.Threading.Tasks;

namespace Core.StateMachine
{
    public interface IState
    {
        Task OnEnter();
        Task OnExit();
    }
}