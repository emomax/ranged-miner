using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
  private Rigidbody2D rigidBody;

  [SerializeField]
  private float baseSpeed = 10f;

  private Vector3 currentDirection;

  void Start()
  {
    this.rigidBody = this.GetComponent<Rigidbody2D>();
    this.rigidBody.AddForce(new Vector3(2f, 2f, 0f).normalized * baseSpeed);
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log("Hit something: " + other.gameObject.tag);
  }
}