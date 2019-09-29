using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMinerBreakoutGame : GameEventListener
{
  private PlayerControlledBall ball;

  public RangedMinerBreakoutGame(PlayerControlledBall ball)
  {
    this.ball = ball;
  }

  public void start()
  {
    // TODO Start and initiate the level!
  }

  public void loadLevel(LevelData level)
  {
    // TODO Load and create the level here!
  }

  public bool isLevelCompleted()
  {
    return false;
  }

  // From GameEventListener
  public override void playerBouncedAgainst(int index)
  {
    throw new NotImplementedException();
  }
}
