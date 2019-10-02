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
      Brick brick = new Brick("b", 0);

      Assert.True(brick.getBrickType().Equals(Brick.BrickType.BRITTLE));
    }

    [Test]
    public void BrickCanBreak()
    {
      Brick brick = new Brick("b", 0);

      brick.takeHit();

      Assert.True(brick.isBroken());
    }

    [Test]
    public void GoldTypeBrickHas3Lives()
    {
      Brick brick = new Brick("g", 0);

      brick.takeHit();
      brick.takeHit();
      Assert.False(brick.isBroken());

      brick.takeHit();
      Assert.True(brick.isBroken());
    }

    [Test]
    public void EmeraldTypeBrickHas5Lives()
    {
      Brick brick = new Brick("e", 0);

      brick.takeHit();
      brick.takeHit();
      brick.takeHit();
      brick.takeHit();
      Assert.False(brick.isBroken());

      brick.takeHit();
      Assert.True(brick.isBroken());
    }
  }
}
