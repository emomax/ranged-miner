using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Brick;

public class IngameBrick : MonoBehaviour
{

  [SerializeField]
  private BrickType brickType;
  private Brick brickData;
  private Collider2D boxCollider;
  private SpriteRenderer spriteRenderer;

  void Start()
  {
    this.boxCollider = this.GetComponent<BoxCollider2D>();
    this.spriteRenderer = this.GetComponent<SpriteRenderer>();
  }

  public void setId(int id)
  {
    this.brickData = new Brick(this.brickType, id);
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
