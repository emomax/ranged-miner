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
  private int id;

  public Brick(string rawBrickType, int id)
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

    this.id = id;
  }

  public BrickType getBrickType()
  {
    return this.brickType;
  }

  public int getId()
  {
    return this.id;
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