using Services;

namespace Infrastructure.ProviderBase
{
  public interface IProvider<T> : IService
  {
    T Instance { get; }
  }
}