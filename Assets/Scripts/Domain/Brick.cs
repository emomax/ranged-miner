using System;
using UnityEngine;

public class Brick
{

  public enum BrickType
  {
    BRITTLE
  }

  private BrickType brickType;
  private int health;

  public Brick(string rawBrickType)
  {
    if (rawBrickType.Equals("x"))
    {
      this.health = 1;
      this.brickType = BrickType.BRITTLE;
    }
    else
    {
      throw new UnityException("Unknown bricktype: " + rawBrickType);
    }
  }

  public BrickType getBrickType()
  {
    return brickType;
  }

  public void takeHit()
  {
    this.health--;
  }

  public bool isBroken()
  {
    return this.health <= 0;
  }
}