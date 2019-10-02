using System;
using UnityEngine;

public class Brick
{

  public enum BrickType
  {
    BRITTLE,
    GOLD
  }

  private BrickType brickType;
  private int health;
  private int id;

  public Brick(string rawBrickType, int id)
  {
    if (rawBrickType.Equals("b"))
    {
      this.health = 1;
      this.brickType = BrickType.BRITTLE;
    }
    else if (rawBrickType.Equals("g"))
    {
      this.health = 3;
      this.brickType = BrickType.GOLD;
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