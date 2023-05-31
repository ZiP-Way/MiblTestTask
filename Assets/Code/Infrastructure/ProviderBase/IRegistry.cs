using Services;

namespace Infrastructure.ProviderBase
{
  public interface IRegistry<T> : IService
  {
    void Registry(T instance);
  }
}