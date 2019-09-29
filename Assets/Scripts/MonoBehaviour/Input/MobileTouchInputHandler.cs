
using UnityEngine;

public class MobileTouchInputHandler : InputHandler
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
    if (Input.touchCount > 0)
    {
      // We only care about touches if less than three fingers are used.
      if (Input.GetTouch(0).position.x > Screen.width / 2)
      {
        rightSideOfScreenTouched = true;
        leftSideOfScreenTouched = false;
      }
      else
      {
        leftSideOfScreenTouched = true;
        rightSideOfScreenTouched = false;
      }
    }
    else
    {
      rightSideOfScreenTouched = false;
      leftSideOfScreenTouched = false;
    }
  }
}