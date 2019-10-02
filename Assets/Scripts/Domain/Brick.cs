using System;
using UnityEngine;

public class Brick
{
  [System.Serializable]
  public enum BrickType
  {
    BRITTLE,
    GOLD,
    EMERALD
  }

  private BrickType brickType;
  private int health;
  private int maxHealth;
  private int id;


  public Brick(string rawBrickType, int id)
  {
    this.id = id;
    this.brickType = parseBrickType(rawBrickType);

    setHealth();
  }

  public Brick(BrickType brickType, int id)
  {
    this.id = id;
    this.brickType = brickType;

    setHealth();
  }

  private void setHealth()
  {
    switch (brickType)
    {
      case BrickType.BRITTLE:
        this.health = 1;
        break;
      case BrickType.GOLD:
        this.health = 3;
        break;
      case BrickType.EMERALD:
        this.health = 5;
        break;
    }

    this.maxHealth = this.health;
  }

  private BrickType parseBrickType(string rawBrickType)
  {
    switch (rawBrickType)
    {
      case "b":
        return BrickType.BRITTLE;
      case "g":
        return BrickType.GOLD;
      case "e":
        return BrickType.EMERALD;
      default:
        throw new UnityException("Unknown bricktype: " + rawBrickType);
    }
  }

  public BrickType getBrickType()
  {
    return this.brickType;
  }

  public int getMaxHealth()
  {
    return this.maxHealth;
  }

  public int getCurrentHealth()
  {
    return this.health;
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