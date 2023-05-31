namespace Services
{
  public class AllServices
  {
    #region Properties

    public static AllServices Container => _instance ?? (_instance = new AllServices());

    #endregion

    #region Fields

    private static AllServices _instance;

    #endregion

    public void RegisterSingle<TService>(TService implementation) where TService : IService =>
      Implementation<TService>.ServiceInstance = implementation;

    public TService Single<TService>() where TService : IService =>
      Implementation<TService>.ServiceInstance;

    private class Implementation<TService> where TService : IService
    {
      public static TService ServiceInstance;
    }
  }
}