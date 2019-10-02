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
      GamePhaseEventListener gameTracker = Substitute.For<GamePhaseEventListener>();

      LevelData level = new LevelData();
      level.addRow(new string[] { "b", "b", "b" }); // index {0, 1, 2}
      level.addRow(new string[] { "b", "b" });      // index  {3, 4}

      RangedMinerBreakoutGame gameRunner = new RangedMinerBreakoutGame();
      gameRunner.registerGamePhaseEventListener(gameTracker);

      gameRunner.loadLevel(level);
      gameRunner.start();

      gameRunner.playerBouncedAgainst(0);
      gameRunner.playerBouncedAgainst(1);
      gameRunner.playerBouncedAgainst(2);
      gameRunner.playerBouncedAgainst(3);
      gameRunner.playerBouncedAgainst(4);

      gameTracker.Received(1).levelCompleted();
    }

    [Test]
    public void GameRunnerProperlyPropagatesGameOverEvent()
    {
      GamePhaseEventListener gameTracker = Substitute.For<GamePhaseEventListener>();

      LevelData level = new LevelData();
      level.addRow(new string[] { "b", "b", "b" }); // index {0, 1, 2}
      level.addRow(new string[] { "b", "b" });      // index  {3, 4}

      RangedMinerBreakoutGame gameRunner = new RangedMinerBreakoutGame();
      gameRunner.registerGamePhaseEventListener(gameTracker);

      gameRunner.loadLevel(level);
      gameRunner.start();

      gameRunner.playerHitLoseZone();

      gameTracker.Received(1).gameOver();
    }
  }
}
