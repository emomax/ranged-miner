using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMinerBreakoutGame
{
  private Brick[] bricks;
  private int brokenBricks = 0;
  private bool gameIsOver = false;

  public void loadLevel(LevelData level)
  {
    this.bricks = new Brick[level.getTotalNumberOfBricks()];
    this.brokenBricks = 0;
    this.gameIsOver = false;

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
    }
    else
    {
      Debug.Log("Broken bricks: " + brokenBricks + ", out of " + bricks.Length);
    }
  }

  public void playerHitLoseZone()
  {
    this.gameIsOver = true;
  }

  public bool isGameOver()
  {
    return this.gameIsOver;
  }
}
