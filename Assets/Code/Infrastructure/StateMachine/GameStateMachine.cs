using System;
using System.Collections.Generic;

namespace Infrastructure.StateMachine
{
  public class GameStateMachine : IStateMachine
  {
    #region Feilds

    private Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    #endregion

    public GameStateMachine() => 
      _states = new Dictionary<Type, IExitableState>();

    public void AddState(Type stateType, IExitableState state) => 
      _states.Add(stateType, state);

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
      TState state = ChangeState<TState>();
      state.Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      _activeState?.Exit();

      TState state = GetState<TState>();
      _activeState = state;

      return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState =>
      _states[typeof(TState)] as TState;
  }
}