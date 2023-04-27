using System.Threading.Tasks;
using Core.StateMachine;

namespace SarrrGames.GoldenRush.Core.StateMachine.States
{
    public class WinState : BaseState
    {
        private readonly MenuState _menuState;

        public WinState(IStateMachine stateMachine, MenuState menuState) : base(stateMachine)
        {
            _menuState = menuState;
        }

        public override Task OnEnter()
        {
            StateMachine.SetState(_menuState);
            return Task.CompletedTask;
        }

        public override Task OnExit()
        {
            return Task.CompletedTask;
        }
    }
}
