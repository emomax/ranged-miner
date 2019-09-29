using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
  public class ApplicationTests
  {
    [Test]
    public void SimpleMapIsFinishable()
    {
      // Let's give the ball means of communcating back to the engine.
      GameEventBridge eventBridge = new GameEventBridge();
      PlayerControlledBall ball = new PlayerControlledBall(eventBridge);

      LevelData level = new LevelData();
      level.addRow({ "x", "x", "x"}); // index {0, 1, 2}
      level.addRow({ "x", "x"});      // index  {3, 4}

      RangedMinerBreakoutGame game = new RangedMinerBreakoutGame(ball);
      eventBridge.registerListener(game);

      game.loadLevel(level);
      game.start();

      // This will be invoked from the ball upon colliding with tiles.
      eventBridge.playerBouncedAgainst(0);
      eventBridge.playerBouncedAgainst(1);
      eventBridge.playerBouncedAgainst(2);
      eventBridge.playerBouncedAgainst(3);
      eventBridge.playerBouncedAgainst(4);

      Assert.True(game.isLevelCompleted());
    }
  }
}
