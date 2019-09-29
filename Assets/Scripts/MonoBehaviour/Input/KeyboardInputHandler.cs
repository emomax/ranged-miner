
using UnityEngine;

public class KeyboardInputHandler : InputHandler
{
  private bool leftSideOfScreenTouched = false;
  private bool rightSideOfScreenTouched = false;

  public override bool shouldMoveLeft()
  {
    return leftSideOfScreenTouched;
  }

  public override bool shouldMoveRight()
  {
    return rightSideOfScreenTouched;
  }

  public void Update()
  {

    if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow))
    {
      rightSideOfScreenTouched = true;
      leftSideOfScreenTouched = false;
    }
    else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
    {
      leftSideOfScreenTouched = true;
      rightSideOfScreenTouched = false;
    }
    else
    {
      rightSideOfScreenTouched = false;
      leftSideOfScreenTouched = false;
    }
  }
}