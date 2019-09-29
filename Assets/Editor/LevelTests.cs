using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
  public class LevelTests
  {
    [Test]
    public void SimpleMapIsParseable()
    {
      LevelData level = new LevelData();
      level.addRow(new string[] { "x", "x", "x" });
      level.addRow(new string[] { "x", "x" });

      Assert.That(level.getRows().Count == 2);
      Assert.That(level.getTotalNumberOfBricks() == 5);
    }
  }
}
