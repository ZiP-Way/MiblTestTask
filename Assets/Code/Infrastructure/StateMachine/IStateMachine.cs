using System;
using Services;

namespace Infrastructure.StateMachine
{
  public interface IStateMachine : IService
  {
    void AddState(Type stateType, IExitableState state);
    void Enter<TState>() where TState : class, IState;
    void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
  }
}