using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BouncyBall : MonoBehaviour
{
  [System.Serializable]
  private class onBrickCollision : UnityEvent<int> { }

  [SerializeField]
  private onBrickCollision notifyGameRunner;

  [SerializeField]
  private float speed = 3f;

  private Rigidbody2D rigidBody;
  private Vector3 currentDirection;
  private bool isLoaded;


  void Start()
  {
    this.rigidBody = this.GetComponent<Rigidbody2D>();
    this.isLoaded = false;
  }

  public void FixedUpdate()
  {
    // Seeing as Unity's physics doesn't want to co-operate fully, we'll have to put 
    // some suspenders on there..

    Vector2 direction = this.rigidBody.velocity.normalized;
    this.rigidBody.velocity = direction * speed;
  }

  public void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.name.StartsWith("brick-"))
    {
      // We hit a brick! Poke it!
      IngameBrick brick = other.gameObject.GetComponent<IngameBrick>();
      brick.wasHit();

      notifyGameRunner.Invoke(brick.getId());
    }
  }

  public void reset()
  {
    this.rigidBody.velocity = Vector3.zero;
    this.transform.localPosition = new Vector3(0, -0.3f, 0);
  }

  public void shoot()
  {
    this.rigidBody.AddForce(new Vector3(1f, 1f, 0f).normalized);
  }

  public void freezeInPlace()
  {
    this.rigidBody.velocity = Vector3.zero;
  }
}