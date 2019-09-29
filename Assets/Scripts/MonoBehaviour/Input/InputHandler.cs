
using UnityEngine;

// Facade towards input handling. Controllers? Keyboards? Touch device?
// We got you covered!
public abstract class InputHandler : MonoBehaviour
{
  public abstract bool shouldMoveLeft();
  public abstract bool shouldMoveRight();
}