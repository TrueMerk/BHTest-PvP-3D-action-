namespace Core.StateMachine
{
    public interface IStateMachine
    {
        void SetState(IState state);
    }
}