using System.Threading.Tasks;
using Core.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SarrrGames.GoldenRush.Core.StateMachine.States
{
    public class LoadState : BaseState
    {
        private readonly MenuState _menuState;

        public LoadState(IStateMachine stateMachine, MenuState menuState) : base(stateMachine)
        {
            _menuState = menuState;
        }

        public override Task OnEnter()
        {
            SceneManager.LoadSceneAsync($"MainScene", LoadSceneMode.Additive).completed += LoadSceneComplete;
            return Task.CompletedTask;
        }

        public override Task OnExit()
        {
            return Task.CompletedTask;
        }

        private void LoadSceneComplete(AsyncOperation operation)
        {
            StateMachine.SetState(_menuState);
        }
    }
}