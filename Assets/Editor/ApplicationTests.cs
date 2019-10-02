using System.Collections;
using System.Collections.Generic;
using NSubstitute;
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
      LevelData level = new LevelData();
      level.addRow(new string[] { "b", "b", "b" }); // index {0, 1, 2}
      level.addRow(new string[] { "b", "b" });      // index  {3, 4}

      MagicMinerBreakoutGame gameRunner = new MagicMinerBreakoutGame();

      gameRunner.loadLevel(level);

      gameRunner.playerBouncedAgainst(0);
      gameRunner.playerBouncedAgainst(1);
      gameRunner.playerBouncedAgainst(2);
      gameRunner.playerBouncedAgainst(3);
      gameRunner.playerBouncedAgainst(4);

      Assert.True(gameRunner.isLevelCompleted());
    }

    [Test]
    public void GameIsOverIfBallHitsLoseZone()
    {
      LevelData level = new LevelData();
      level.addRow(new string[] { "b", "b", "b" }); // index {0, 1, 2}
      level.addRow(new string[] { "b", "b" });      // index  {3, 4}

      MagicMinerBreakoutGame gameRunner = new MagicMinerBreakoutGame();

      gameRunner.loadLevel(level);

      gameRunner.playerHitLoseZone();

      Assert.False(gameRunner.isLevelCompleted());
      Assert.True(gameRunner.isGameOver());
    }
  }
}
