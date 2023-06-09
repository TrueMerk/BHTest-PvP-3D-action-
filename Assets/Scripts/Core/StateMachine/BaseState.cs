﻿using System.Threading.Tasks;

namespace Core.StateMachine
{
    public abstract class BaseState : IState
    {
        protected IStateMachine StateMachine { get; }

        protected BaseState(IStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
        
        public abstract Task OnEnter();

        public abstract Task OnExit();
    }
}