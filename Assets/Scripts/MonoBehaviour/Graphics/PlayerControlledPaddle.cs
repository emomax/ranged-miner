
using UnityEngine;

public class PlayerControlledPaddle : MonoBehaviour
{
  private Rigidbody2D rigidBody;

  [SerializeField]
  private InputHandler inputHandler;
  [SerializeField]
  private float speed = 0.8f;

  public void Start()
  {
    this.rigidBody = this.GetComponent<Rigidbody2D>();

    // Moves the GameObject using its transform.
    rigidBody.isKinematic = true;
  }

  public void reset()
  {
    this.transform.localPosition = new Vector3(0, -0.7f, 0);
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
