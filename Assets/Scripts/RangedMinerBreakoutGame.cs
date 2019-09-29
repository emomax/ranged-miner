using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMinerBreakoutGame : IngameEventListener
{
  private PlayerControlledBall ball;
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

    List<List<Brick>> rows = level.getRows();
    int currentIndex = 0;

    for (int i = 0; i < level.getRows().Count; i++)
    {
      List<Brick> currentRow = rows[i];

      for (int j = 0; j < currentRow.Count; j++)
      {
        Debug.Log("Created brick at index " + currentIndex);
        this.bricks[currentIndex++] = currentRow[j];
      }
    }
  }

  public bool isLevelCompleted()
  {
    return false;
  }

  public void registerGamePhaseEventListener(GamePhaseEventListener listener)
  {
    this.gamePhaseEventListeners.Add(listener);
  }

  // From IngameEventListener
  public override void playerBouncedAgainst(int index)
  {
    Debug.Log("Tried to take hit for brick at index " + index);
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
}
