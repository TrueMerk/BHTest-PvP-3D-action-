using System.Threading.Tasks;
using Core;
using Core.StateMachine;
using UnityEngine;

namespace SarrrGames.GoldenRush.Core.StateMachine.States
{
    public class GameplayState : BaseState
    {
        private readonly IGameEngine _gameEngine;

        public GameplayState(IStateMachine stateMachine, IGameEngine gameEngine) : base(stateMachine)
        {
            _gameEngine = gameEngine;
        }

        public override Task OnEnter()
        {
            _gameEngine.StartGameplay();
            return Task.CompletedTask;
        }

        public override Task OnExit()
        {
            return Task.CompletedTask;
        }
    }
}
