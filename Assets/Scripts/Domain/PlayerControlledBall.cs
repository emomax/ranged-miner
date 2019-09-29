using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlledBall : MonoBehaviour
{
  private GameEventBridge eventBridge;

  public PlayerControlledBall(GameEventBridge eventBridge)
  {
    this.eventBridge = eventBridge;
  }
}
