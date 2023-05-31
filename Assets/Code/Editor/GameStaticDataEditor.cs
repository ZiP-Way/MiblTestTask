using Data;
using EnemyLogic;
using StaticData.Game;
using UnityEditor;
using UnityEngine;

namespace Editor
{
  [CustomEditor(typeof(GameStaticData))]
  public class GameStaticDataEditor : UnityEditor.Editor
  {
    private const string PlayerSpawnPointTag = "PlayerSpawnPoint";

    public override void OnInspectorGUI()
    {
      base.OnInspectorGUI();

      GameStaticData gameData = (GameStaticData) target;

      if (GUILayout.Button("Collect"))
      {
        EnemySpawnArea enemySpawnArea = FindObjectOfType<EnemySpawnArea>();
        AreaData enemyAreaData = new AreaData
        {
          Center = enemySpawnArea.Center,
          Size = enemySpawnArea.Size
        };
        
        gameData.EnemyAreaData = enemyAreaData;
        
        Transform characterSpawnPoint = GameObject.FindWithTag(PlayerSpawnPointTag).transform;
        gameData.CharacterSpawnPosition = characterSpawnPoint.position;
      }
      
      EditorUtility.SetDirty(target);
    }
  }
}