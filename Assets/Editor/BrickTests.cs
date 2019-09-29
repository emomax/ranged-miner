using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
  public class BrickTests
  {
    [Test]
    public void CanParseBasicBrickFromRawData()
    {
      Brick brick = new Brick("x");

      Assert.True(brick.getBrickType().Equals(Brick.BrickType.BRITTLE));
    }
  }
}
