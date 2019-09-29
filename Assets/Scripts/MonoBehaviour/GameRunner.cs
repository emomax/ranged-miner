using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
  private RangedMinerBreakoutGame application;

  [SerializeField]
  private List<GamePhaseEventListener> listeners;

  [SerializeField]
  private LevelBuilder levelBuilder;

  void Start()
  {
    LevelData levelData = new LevelData();

    levelData.addRow(new string[] { "x", "x", "x", "x" });
    levelData.addRow(new string[] { "x", "x", "x" });
    levelData.addRow(new string[] { "x", "x", "x", "x" });

    application = new RangedMinerBreakoutGame();
    application.loadLevel(levelData);

    levelBuilder.buildLevel(levelData);

    application.start();
  }

  public void playerCollidedWith(int indexOfBrick)
  {
    application.playerBouncedAgainst(indexOfBrick);
  }
}