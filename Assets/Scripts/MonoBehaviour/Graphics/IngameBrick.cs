using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameBrick : MonoBehaviour
{
  private Brick brickData;
  private Collider2D boxCollider;
  private SpriteRenderer spriteRenderer;

  void Start()
  {
    this.boxCollider = this.GetComponent<BoxCollider2D>();
    this.spriteRenderer = this.GetComponent<SpriteRenderer>();
  }

  public void setBrick(Brick brick)
  {
    this.brickData = brick;
  }

  public void wasHit()
  {
    brickData.takeHit();

    if (brickData.isBroken())
    {
      Debug.Log("I died! ");
      this.boxCollider.enabled = false;
      this.spriteRenderer.enabled = false;
    }
  }

  public int getId()
  {
    return brickData.getId();
  }
}
