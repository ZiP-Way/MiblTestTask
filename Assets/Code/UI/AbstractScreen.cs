namespace UI
{
  public class AbstractScreen<TModel> : WindowBase where TModel : IViewModel
  {
    #region Fields

    protected TModel ViewModel;

    #endregion
  }
}