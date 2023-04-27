using System.Linq;
using UnityEngine;

namespace Core.StateMachine
{
    public class StateMachine : IStateMachine
    {
        private IState _currentState;

        public async void SetState(IState state)
        {
            Debug.Log($"<b>State Machine:</b> Enter State {state.GetType().ToString().Split('.').Last()}");
            
            if (_currentState != null)
            {
                await _currentState.OnExit();
            }

            _currentState = state;
            await _currentState.OnEnter();
        }
    }
}
