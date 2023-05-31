using System.Collections.Generic;
using Services;

namespace EnemyLogic.Services.Container
{
  public interface IEnemiesContainer : IService
  {
    IList<EnemyBase> Enemies { get; }
    void Add(EnemyBase enemy);
    void Clear();
  }
}