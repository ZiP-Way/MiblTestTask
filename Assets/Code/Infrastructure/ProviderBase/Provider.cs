namespace Infrastructure.ProviderBase
{
  public class Provider<T> : IProvider<T>, IRegistry<T> where T : class
  {
    public T Instance { get; private set; }

    public void Registry(T instance) => 
      Instance = instance;
  }
}