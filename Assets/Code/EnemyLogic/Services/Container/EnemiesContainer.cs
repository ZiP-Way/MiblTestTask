using System.Collections.Generic;

namespace EnemyLogic.Services.Container
{
  public class EnemiesContainer : IEnemiesContainer
  {
    #region Properties

    public IList<EnemyBase> Enemies => _enemies.AsReadOnly();

    #endregion
    
    #region Fields

    private List<EnemyBase> _enemies;

    #endregion

    public EnemiesContainer() => 
      _enemies = new List<EnemyBase>();

    public void Add(EnemyBase enemy) => 
      _enemies.Add(enemy);

    public void Clear() => 
      _enemies.Clear();
  }
}