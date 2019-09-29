using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BouncyBall : MonoBehaviour
{
  private Rigidbody2D rigidBody;

  [SerializeField]
  private float baseSpeed = 0.01f;

  private Vector3 currentDirection;


  [System.Serializable]
  private class onBrickCollision : UnityEvent<int> { }

  [SerializeField]
  private onBrickCollision notifyGameRunner;

  void Start()
  {
    this.rigidBody = this.GetComponent<Rigidbody2D>();
    this.rigidBody.AddForce(new Vector3(2f, 2f, 0f).normalized * baseSpeed);
  }

  public void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log("Hit something: " + other.gameObject.name);

    if (other.gameObject.name.StartsWith("brick-"))
    {
      // We hit a brick! Poke it!
      IngameBrick brick = other.gameObject.GetComponent<IngameBrick>();
      brick.wasHit();

      notifyGameRunner.Invoke(brick.getId());
    }
  }

  public void FixedUpdate()
  {
    // Seeing as Unity's physics doesn't want to co-operate fully, we'll have to put 
    // some suspenders on there..

    Vector2 direction = rigidBody.velocity.normalized;
    rigidBody.velocity = direction * baseSpeed;
  }
}