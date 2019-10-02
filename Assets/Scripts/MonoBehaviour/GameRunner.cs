using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
  private RangedMinerBreakoutGame application;

  [SerializeField]
  private List<GameEventListener> listeners;


  [SerializeField]
  private LevelBuilder levelBuilder;

  void Start()
  {
    LevelData levelData = new LevelData();

    levelData.addRow(new string[] { "b", "b", "b", "b", "b", "b" });
    levelData.addRow(new string[] { "b", "g", "e", "g", "b" });
    levelData.addRow(new string[] { "b", "b", "b", "b", "b", "b" });

    application = new RangedMinerBreakoutGame();
    application.loadLevel(levelData);

    levelBuilder.buildLevel(levelData);
    application.start();
  }

  public void playerCollidedWith(int indexOfBrick)
  {
    application.playerBouncedAgainst(indexOfBrick);
  }

  // Triggered by LoseZone upon player entering it.
  public void gameOver()
  {
    application.playerHitLoseZone();
  }
}