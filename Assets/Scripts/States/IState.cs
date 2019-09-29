public interface IState
{
    void Enter(); //happens on state creation? but states are also instanced objects 
    void Execute(); //happens once per frame. 
    void Exit(); //usually called by execute to clean up current state transition into next state.
}