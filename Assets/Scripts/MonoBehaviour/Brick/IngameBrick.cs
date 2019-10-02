using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Brick;

public class IngameBrick : MonoBehaviour
{
  [SerializeField]
  private BrickType brickType;

  [SerializeField]
  private List<string> animations;

  private Brick brickData;
  private Collider2D boxCollider;
  private SpriteRenderer spriteRenderer;
  private Animator animator;

  void Start()
  {
    this.boxCollider = this.GetComponent<BoxCollider2D>();
    this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    this.animator = this.GetComponent<Animator>();
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
      this.boxCollider.enabled = false;
      this.spriteRenderer.enabled = false;
    }
    else
    {
      this.animator.Play(animations[this.brickData.getMaxHealth() - this.brickData.getCurrentHealth() - 1]);
    }
  }

  public int getId()
  {
    return brickData.getId();
  }
}
