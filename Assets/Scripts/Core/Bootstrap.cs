using Core.StateMachine;
using SarrrGames.GoldenRush.Core.StateMachine;
using SarrrGames.GoldenRush.Core.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject]
        public void Construct(LoadState loadState, IStateMachine stateMachine)
        {
            stateMachine.SetState(loadState);
        }
    }
}
