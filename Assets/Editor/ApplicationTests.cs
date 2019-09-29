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

      // Let's give the ball means of communcating back to the engine.
      IngameEventBridge ingameEventBridge = new IngameEventBridge();

      LevelData level = new LevelData();
      level.addRow(new string[] { "x", "x", "x" }); // index {0, 1, 2}
      level.addRow(new string[] { "x", "x" });      // index  {3, 4}

      RangedMinerBreakoutGame gameRunner = new RangedMinerBreakoutGame();
      gameRunner.registerGamePhaseEventListener(gameTracker);
      ingameEventBridge.registerListener(gameRunner);

      gameRunner.loadLevel(level);
      gameRunner.start();

      // This will be invoked from the ball upon colliding with tiles.
      ingameEventBridge.playerBouncedAgainst(0);
      ingameEventBridge.playerBouncedAgainst(1);
      ingameEventBridge.playerBouncedAgainst(2);
      ingameEventBridge.playerBouncedAgainst(3);
      ingameEventBridge.playerBouncedAgainst(4);

      gameTracker.Received(1).levelCompleted();
    }
  }
}
