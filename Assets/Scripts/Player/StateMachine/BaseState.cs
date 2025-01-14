public abstract class BaseState
{
    protected FSM _fsm;

    public BaseState(FSM fsm)
    {
        _fsm = fsm;
    }
    
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

}
