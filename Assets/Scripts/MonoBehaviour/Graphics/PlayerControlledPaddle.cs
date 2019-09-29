
using UnityEngine;

public class PlayerControlledPaddle : MonoBehaviour
{
  private Rigidbody2D rigidBody;
  private PaddleGraphics graphics;

  [SerializeField]
  private InputHandler inputHandler;
  [SerializeField]
  private float speed = 0.8f;

  public void Start()
  {
    this.graphics = this.GetComponentInChildren<PaddleGraphics>();
    this.rigidBody = this.GetComponent<Rigidbody2D>();

    // Moves the GameObject using its transform.
    rigidBody.isKinematic = true;
  }

  public void FixedUpdate()
  {
    if (inputHandler.shouldMoveLeft())
    {
      this.rigidBody.MovePosition(transform.position + Vector3.left * speed);
    }
    else if (inputHandler.shouldMoveRight())
    {
      this.rigidBody.MovePosition(transform.position + Vector3.right * speed);
    }
  }
}
