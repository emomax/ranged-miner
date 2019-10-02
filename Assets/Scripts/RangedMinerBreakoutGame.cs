using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMinerBreakoutGame
{
  private Brick[] bricks;
  private int brokenBricks = 0;
  private List<GamePhaseEventListener> gamePhaseEventListeners;

  public RangedMinerBreakoutGame()
  {
    this.gamePhaseEventListeners = new List<GamePhaseEventListener>();
  }

  public void start()
  {
    foreach (var listener in gamePhaseEventListeners)
    {
      listener.gameStarted();
    }
  }

  public void loadLevel(LevelData level)
  {
    this.bricks = new Brick[level.getTotalNumberOfBricks()];
    this.brokenBricks = 0;

    List<List<Brick>> rows = level.getRows();
    int currentIndex = 0;

    for (int i = 0; i < level.getRows().Count; i++)
    {
      List<Brick> currentRow = rows[i];

      for (int j = 0; j < currentRow.Count; j++)
      {
        this.bricks[currentIndex++] = currentRow[j];
      }
    }
  }

  public bool isLevelCompleted()
  {
    return brokenBricks == bricks.Length;
  }

  public void registerGamePhaseEventListener(GamePhaseEventListener listener)
  {
    this.gamePhaseEventListeners.Add(listener);
  }

  public void playerBouncedAgainst(int index)
  {
    this.bricks[index].takeHit();

    if (bricks[index].isBroken())
    {
      brokenBricks++;
      Debug.Log("Brick was broken! Number of broken bricks: " + brokenBricks);
    }

    if (brokenBricks == bricks.Length)
    {
      Debug.Log("All bricks are broken! Player won!");
      foreach (var listener in gamePhaseEventListeners)
      {
        listener.levelCompleted();
      }
    }
    else
    {
      Debug.Log("Broken bricks: " + brokenBricks + ", out of " + bricks.Length);
    }
  }

  public void playerHitLoseZone()
  {
    foreach (var listener in gamePhaseEventListeners)
    {
      listener.gameOver();
    }
  }
}
