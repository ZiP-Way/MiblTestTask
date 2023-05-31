namespace Pool
{
  public interface IPoolElement
  {
    bool IsActive { get; }
    void Activate();
    void Deactivate();
  }

}